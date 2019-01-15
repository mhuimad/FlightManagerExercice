using FlightManager.Module.Calculator;
using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Module.Ports;
using System.Collections.Generic;


namespace FlightManager.Module
{
    public class FlightModule : IFlightModule
    {

        private readonly IFlightRepository _flightRepo;
        private readonly FlightCalculator _calculator;


        public FlightModule(IFlightRepository flightRepo)
        {
            _flightRepo = flightRepo;
            _calculator = new FlightCalculator();
        }

        public Flight CreateFlight(Flight flight)
        {
            _flightRepo.CreateFlight(flight);
            _calculator.ConsolidateFlight(flight);
            return flight;
        }

        public List<Flight> LoadFlights()
        {
            var flights = _flightRepo.LoadFlights();
            _calculator.ConsolidateFlights(flights);
            return flights;
        }

        public Flight UpdateFlight(Flight flight)
        {
            _flightRepo.UpdateFlight(flight);
            _calculator.ConsolidateFlight(flight);
            return flight;
        }

        public Airport GetAirportById(int id)
        {
            return _flightRepo.GetAirportById(id);
        }

        public List<Airport> LoadAirports()
        {
            return _flightRepo.LoadAirports();
        }

        public Flight GetFlightById(int flightId)
        {
            return _flightRepo.GetFlightById(flightId); 
        }
    }
}
