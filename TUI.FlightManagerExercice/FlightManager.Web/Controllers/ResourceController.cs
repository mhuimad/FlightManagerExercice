using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FlightManager.Web.Controllers
{
    [Route("resource")]
    [ApiController]
    public class ResourceController : Controller
    {

        private readonly IFlightModule _resourceModule;

        public ResourceController(IFlightModule resourceModule)
        {
            _resourceModule = resourceModule;
        }

        // GET: api/Airport
        [HttpGet]
        [Route("airport")]
        [ProducesResponseType(typeof(IEnumerable<Airport>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Exception), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public JsonResult Get()
        {
            var airports = _resourceModule.LoadAirports();
            if (airports == null || !airports.Any())
            {
                return Json(HttpStatusCode.NoContent);
            }
            return Json(airports);
        }
        
    }
}
