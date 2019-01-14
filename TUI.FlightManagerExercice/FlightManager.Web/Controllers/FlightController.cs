using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace FlightManager.Web.Controllers
{
    [Route("flight")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightModule _flightModule;


        public FlightController(IFlightModule flightModule)
        {
            _flightModule = flightModule;
        }

        // GET: api/Flight
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FlightViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Exception), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public JsonResult Get()
        {
            var flights = _flightModule.LoadFlights();
            if (flights == null || !flights.Any())
            {
                return Json(HttpStatusCode.NoContent);
            }
            var result = flights.Select(f => MapEntityToViewModel(f));
            return Json(result);
        }





        // POST: api/Flight
        [HttpPost]
        [ProducesResponseType(typeof(FlightViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Exception), (int)HttpStatusCode.InternalServerError)]
        public JsonResult Post([FromBody] FlightViewModel flightViewModel)
        {
            var flight = MapViewModelToEntity(flightViewModel);
            if (flight == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            var response = _flightModule.CreateFlight(flight);
            return Json(MapEntityToViewModel(response));
        }



        // PUT: api/Flight
        [HttpPut]
        [ProducesResponseType(typeof(FlightViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Exception), (int)HttpStatusCode.InternalServerError)]
        public JsonResult Put(FlightViewModel flightViewModel)
        {
            var flight = MapViewModelToEntity(flightViewModel);
            if (flight == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            var response = _flightModule.UpdateFlight(flight);
            return Json(MapEntityToViewModel(response));
        }




        private Flight MapViewModelToEntity(FlightViewModel flightViewModel)
        {
            var airportOrigin = _flightModule.GetAirportById(flightViewModel.OriginAirportId);
            var destinationAirport = _flightModule.GetAirportById(flightViewModel.DestinationAirportId);
            var flight = new Flight()
            {
                FlightId = flightViewModel.FlightId,
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
                DestinationAirport = flight.DestinationAirport.AirportName,
                OriginAirport = flight.OriginAirport.AirportName,
                DistanceInKM = flight.DistanceInKM,
                Fuel = flight.AmountOfFuel
            };
        }
    }
}
