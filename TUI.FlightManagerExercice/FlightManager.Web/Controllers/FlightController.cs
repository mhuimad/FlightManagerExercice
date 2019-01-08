using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Web.Controllers
{
    [Route("Flight")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightModule _flightModule;
        private readonly IResourceModule _resourceModule;


        public FlightController(IFlightModule flightModule, IResourceModule resourceModule)
        {
            _flightModule = flightModule;
            _resourceModule = resourceModule;
        }

        // GET: api/Flight
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Flight
        [HttpPost]
        public JsonResult Post([FromBody] FlightCreationViewModel flightCreationViewModel)
        {
            var flight = MapViewModelToEntity(flightCreationViewModel);
            if (flight == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }

            var response = _flightModule.CreateFlight(flight);
            if (!response.IsValid)
            {
                var jsonResponse = Json(response);
                jsonResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                return jsonResponse;
            }
            return Json(HttpStatusCode.OK);
        }

       

        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private Flight MapViewModelToEntity(FlightCreationViewModel flightCreationViewModel)
        {
            var airportOrigin = _resourceModule.GetAirportById(flightCreationViewModel.OriginAirportId);
            var destinationAirport = _resourceModule.GetAirportById(flightCreationViewModel.DestinationAirportId);

            var flight = new Flight()
            {
                AircraftFuelConsumption = flightCreationViewModel.AircraftFuelConsumption,
                DestinationAirport = destinationAirport,
                OriginAirport = airportOrigin
            };

            return flight;
        }
    }
}
