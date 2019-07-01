using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class OriginCharges
    {
        public int Id { get; set; }
        public int? CarrierId { get; set; }
        public double? Rate { get; set; }
        public int? Units { get; set; }
        public string Currency { get; set; }
        public int? QuotationId { get; set; }

        public virtual AirCarrier Carrier { get; set; }
        public virtual Quotation Quotation { get; set; }
    }
}
