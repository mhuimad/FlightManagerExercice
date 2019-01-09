using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }
        public Airport OriginAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public int OriginAirportId { get; set; }

        public int DestinationAirportId { get; set; }

        public double DistanceInKM { get; set; }

        public int AircraftFuelConsumption { get; set; }

        public int Fuel { get; set; }
    }
}
