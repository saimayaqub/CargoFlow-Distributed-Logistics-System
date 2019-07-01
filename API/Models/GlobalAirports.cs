using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class GlobalAirports
    {
        public GlobalAirports()
        {
            CargoDetailDestination = new HashSet<CargoDetail>();
            CargoDetailOrigin = new HashSet<CargoDetail>();
        }

        public int AirportId { get; set; }
        public string IcaoCode { get; set; }
        public string IataCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? LatDeg { get; set; }
        public int? LatMin { get; set; }
        public int? LatSec { get; set; }
        public string LatDir { get; set; }
        public int? LonDeg { get; set; }
        public int? LonMin { get; set; }
        public int? LonSec { get; set; }
        public string LonDir { get; set; }
        public int? Altitude { get; set; }
        public double? LatDecimal { get; set; }
        public double? LonDecimal { get; set; }

        public virtual ICollection<CargoDetail> CargoDetailDestination { get; set; }
        public virtual ICollection<CargoDetail> CargoDetailOrigin { get; set; }
    }
}
