using FlightManager.Module.Entities;
using System.Collections.Generic;

namespace FlightManager.Module.Ports
{
    public interface IFlightRepository
    {
        int? CreateFlight(Flight flight);
        List<Flight> LoadFlights();
        Flight GetFlightById(int id);
        int UpdateFlight(Flight flight);
        List<Airport> LoadAirports();
        Airport GetAirportById(int id);
    }
}
