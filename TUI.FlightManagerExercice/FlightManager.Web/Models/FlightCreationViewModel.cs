using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Web.Models
{
    public class FlightCreationViewModel
    {
        
        [Required]
        public int OriginAirportId { get; set; }
        [Required]
        public int DestinationAirportId { get; set; }
        [Required]
        public int AircraftFuelConsumption { get; set; }

    }
}
