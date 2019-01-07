using FlightManager.Module.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Ports
{
    public interface IAirportRepository
    {
        List<Airport> GetAllAirports();
    }
}
