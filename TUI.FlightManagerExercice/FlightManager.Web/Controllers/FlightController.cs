using System.Linq;
using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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



        public IActionResult List()
        {
            var flights = _flightModule.LoadFlights();
            if (flights == null || !flights.Any())
            {
                return NoContent();
            }
            var result = flights.Select(f => MapEntityToViewModel(f));
            return View(result);
        }



        [Route("AddNew")]
        public ActionResult AddNew()
        {
            var airports = _flightModule.LoadAirports();
            var selectItemList = airports.Select(p => MapToSelectItem(p)).OrderBy(p => p.Text);
            var model = new FlightViewModel() { OriginAirports = selectItemList, DestinationAirports = selectItemList };
            return View(model);
        }



        [HttpPost]
        public ActionResult Create([FromForm] FlightViewModel flightViewModel)
        {
            if (ModelState.IsValid)
            {
                var flight = MapViewModelToEntity(flightViewModel);
                if (flight == null)
                {
                    return BadRequest();
                }
                _flightModule.CreateFlight(flight);
                return RedirectToAction(nameof(List));
            }

            return BadRequest();
        }


        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var airports = _flightModule.LoadAirports();
            var selectItemList = airports.Select(p => MapToSelectItem(p)).OrderBy(p => p.Text);
            var flight = _flightModule.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }
            var model = MapEntityToViewModel(flight);
            model.OriginAirports = selectItemList;
            model.DestinationAirports = selectItemList;
            return View(model);
        }



        // PUT: api/Flight
        [HttpPost]
        [Route("Update")]
        public ActionResult Update([FromForm]FlightViewModel flightViewModel)
        {
            var flight = MapViewModelToEntity(flightViewModel);
            
            if (_flightModule.GetFlightById(flight.FlightId) == null)
            {
                BadRequest();
            }
            _flightModule.UpdateFlight(flight);
            return RedirectToAction(nameof(List));

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
                DestinationAirportId = flight.DestinationAirportId,
                DestinationAirport = flight.DestinationAirport.AirportName,
                OriginAirportId = flight.OriginAirportId,
                OriginAirport = flight.OriginAirport.AirportName,
                DistanceInKM = flight.DistanceInKM,
                Fuel = flight.AmountOfFuel
            };
        }

        private SelectListItem MapToSelectItem(Airport airport)
        {
            return new SelectListItem((airport.CityName + " || " + airport.AirportName), airport.AirportId.ToString());
        }

    }
}
