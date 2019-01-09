using FlightManager.Module.Entities;
using FlightManager.Module.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Interfaces
{
    public interface IFlightModule
    {
        FlightCreationResult CreateFlight(Flight flight);

        List<Flight> LoadFlights();
        FlightUpdateResult UpdateFlight(Flight flight);


    }
}
