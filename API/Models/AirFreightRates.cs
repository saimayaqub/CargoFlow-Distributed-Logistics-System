using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AirFreightRates
    {
        public int AirFreightRateId { get; set; }
        public int? AirCarrierId { get; set; }
        public string Commodity { get; set; }
        public int? DestinationId { get; set; }
        public double? Weight { get; set; }
        public double? AllInFreightRate { get; set; }
        public string Currency { get; set; }
        public bool? IsSelected { get; set; }
        public int? QuotationId { get; set; }

        public virtual AirCarrier AirCarrier { get; set; }
    }
}
