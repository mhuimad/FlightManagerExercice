using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Module.Ports;
using FlightManager.Module.Values;
using System;
using System.Collections.Generic;


namespace FlightManager.Module
{
    public class FlightModule : IFlightModule
    {

        private readonly IFlightRepository _flightRepo;
        private readonly IResourceRepository _resourceRepo;

        public FlightModule(IFlightRepository flightRepo, IResourceRepository resourceRepo)
        {
            _flightRepo = flightRepo;
            _resourceRepo = resourceRepo;
        }

        public FlightCreationResult CreateFlight(Flight flight)
        {
            _flightRepo.CreateFlight(flight);
            return new FlightCreationResult() { IsValid = true };
        }

        public List<Flight> LoadFlights()
        {
            var flights = _flightRepo.LoadFlights();
            foreach (var item in flights)
            {
                item.DestinationAirport = _resourceRepo.GetAirportById(item.DestinationAirportId);
                item.OriginAirport = _resourceRepo.GetAirportById(item.OriginAirportId);
            }
            return flights;
        }

        public FlightUpdateResult UpdateFlight(Flight flight)
        {

            double distance = CalculateDistance(flight.OriginAirport, flight.DestinationAirport);
            int fuelQuantity = CalculateFuel(distance, flight.AircraftFuelConsumption);
            
            _flightRepo.UpdateFlight(flight);

           
            return new FlightUpdateResult() { IsValid = true, DistanceInKM = distance, Fuel = fuelQuantity };
        }

        private int CalculateFuel(double distance, int aircraftFuelConsumption)
        {
            throw new NotImplementedException();
        }

        private double CalculateDistance(Airport originAirport, Airport destinationAirport)
        {
            throw new NotImplementedException();
        }
    }
}
