using FlightManager.Module.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Interfaces
{
    public interface IResourceModule
    {
        List<Airport> LoadAirports();
        Airport GetAirportById(int originAirportId);
    }
}
