using FlightManager.Module.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Ports
{
    public interface IFlightRepository
    {
        int? CreateFlight(Flight flight);
        List<Flight> LoadFlights();
        void UpdateFlight(Flight flight);
    }
}
