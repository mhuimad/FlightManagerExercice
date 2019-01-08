using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlightManager.Web.Controllers
{
    [Route("Resource")]
    [ApiController]
    public class ResourceController : Controller
    {

        private readonly IResourceModule _resourceModule;

        public ResourceController(IResourceModule resourceModule)
        {
            _resourceModule = resourceModule;
        }

        // GET: api/Airport
        [HttpGet]
        [Route("Airport")]
        [Produces(typeof(IEnumerable<Airport>))]
        public JsonResult Get()
        {
            var airports = _resourceModule.LoadAirports();
            return Json(airports);
        }

        // GET: api/Airport/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
