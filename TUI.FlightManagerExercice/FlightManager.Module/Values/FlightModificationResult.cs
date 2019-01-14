namespace FlightManager.Module.Values
{
    public class FlightModificationResult
    {
        public int FlightId { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public double DistanceInKM { get; set; }
        public int AmountOfFuel { get; set; }

    }
}
