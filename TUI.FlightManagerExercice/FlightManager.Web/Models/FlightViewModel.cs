namespace FlightManager.Web.Models
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public double DistanceInKM { get; set; }
        public double Fuel { get; set; }
        public int OriginAirportId { get; set; }
        public int DestinationAirportId { get; set; }
    }
}
