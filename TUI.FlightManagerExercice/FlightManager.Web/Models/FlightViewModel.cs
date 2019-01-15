using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightManager.Web.Models
{
    public class FlightViewModel
    {
       
        public int FlightId { get; set; }
        [DisplayName("Origin Airport")]
        public string OriginAirport { get; set; }

        [DisplayName("Destination Airport")]
        public string DestinationAirport { get; set; }

        [DisplayName("Distance")]
        [DisplayFormat(DataFormatString = "{0:#.##} kms")]

        public double DistanceInKM { get; set; }

        [DisplayName("Fuel")]
        [DisplayFormat(DataFormatString = "{0:#.##} liters")]
        public double Fuel { get; set; }
        public int OriginAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public IEnumerable<SelectListItem> OriginAirports { get; internal set; }
        public IEnumerable<SelectListItem> DestinationAirports { get; internal set; }
    }
}
