using FlightManager.Module.Entities;
using System.Collections.Generic;

namespace FlightManager.Module.Interfaces
{
    public interface IFlightModule
    {
        Flight CreateFlight(Flight flight);

        List<Flight> LoadFlights();
        Flight UpdateFlight(Flight flight);
        Airport GetAirportById(int id);
        List<Airport> LoadAirports();


    }
}
