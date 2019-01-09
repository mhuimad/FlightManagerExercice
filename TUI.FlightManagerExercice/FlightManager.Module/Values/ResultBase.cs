using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Values
{
    public class ResultBase
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public double DistanceInKM { get; set; }
        public int Fuel { get; set; }
    }
}
