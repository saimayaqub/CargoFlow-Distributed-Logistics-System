using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class DestinationChargesDd
    {
        public int Id { get; set; }
        public int? CustomClearance { get; set; }
        public int? AirportCharges { get; set; }
        public int? TruckingCharges { get; set; }
        public int? OtherCharges { get; set; }
        public string Currency { get; set; }
        public int? QuotationId { get; set; }

        public virtual Quotation Quotation { get; set; }
    }
}
