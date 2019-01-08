using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Module.Ports;
using FlightManager.Module.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module
{
    public class FlightModule : IFlightModule
    {

        private readonly IFlightRepository _flightRepo;

        public FlightModule(IFlightRepository flightRepo)
        {
            _flightRepo = flightRepo;
        }

        public FlightCreationResult CreateFlight(Flight flight)
        {
            _flightRepo.CreateFlight(flight);
            return new FlightCreationResult() { IsValid = true };
        }
    }
}
