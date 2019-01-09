using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Module.Values;
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
        [Produces(typeof(IEnumerable<FlightViewModel>))]
        public JsonResult Get()
        {
            var flights = _flightModule.LoadFlights();
            if (flights == null || !flights.Any())
            {
                return Json(HttpStatusCode.NoContent);
            }
            var result = flights.Select(p => MapEntityToViewModel(p));
            return Json(result);
        }



        // GET: api/Flight/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Flight
        [HttpPost]
        [Produces(typeof(FlightCreationResult))]
        public JsonResult Post([FromBody] FlightViewModel flightViewModel)
        {
            var flight = MapViewModelToEntity(flightViewModel);
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
            return Json(response);
        }



        // PUT: api/Flight
        [HttpPut]
        [Produces(typeof(FlightUpdateResult))]
        public JsonResult Put(FlightViewModel flightViewModel)
        {
            var flight = MapViewModelToEntity(flightViewModel);
            var result = _flightModule.UpdateFlight(flight);

            return Json(result);

        }

       


        private Flight MapViewModelToEntity(FlightViewModel flightViewModel)
        {
            var airportOrigin = _resourceModule.GetAirportById(flightViewModel.OriginAirportId);
            var destinationAirport = _resourceModule.GetAirportById(flightViewModel.DestinationAirportId);
            var flight = new Flight()
            {
                FlightId = flightViewModel.FlightId,
                AircraftFuelConsumption = flightViewModel.AircraftFuelConsumption,
                DestinationAirport = destinationAirport,
                OriginAirport = airportOrigin
            };

            return flight;
        }


        private FlightViewModel MapEntityToViewModel(Flight flight)
        {
            return new FlightViewModel()
            {
                FlightId = flight.FlightId,
                AircraftFuelConsumption = flight.AircraftFuelConsumption,
                DestinationAirport = flight.DestinationAirport.AirportName,
                OriginAirport = flight.OriginAirport.AirportName,
                DistanceInKM = flight.DistanceInKM,
                Fuel = flight.Fuel
            };
        }
    }
}
