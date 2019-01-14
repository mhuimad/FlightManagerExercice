namespace FlightManager.Module.Entities
{
    public class Flight
    {
        public int FlightId { get; private set; }
        public Airport OriginAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public int OriginAirportId { get; set; }

        public int DestinationAirportId { get; set; }

        public double DistanceInKM { get; set; }

        

        public double AmountOfFuel { get; set; }
    }
}
