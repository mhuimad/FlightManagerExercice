namespace FlightManager.Module.Entities
{
    public class Airport
    {
        public int AirportId { get; private set; }
        public string AirportCode { get; private set; }
        public string AirportName { get; private set; }
        public string CityName { get; private set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        

    }
}
