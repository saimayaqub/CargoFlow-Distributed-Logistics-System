using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class CargoDetail
    {
        public CargoDetail()
        {
            CartonSpecs = new HashSet<CartonSpecs>();
        }

        public int CargoDetailId { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public string Commodity { get; set; }
        public double? ApproxWeight { get; set; }
        public double? ActualWeight { get; set; }
        public DateTime? CargoDeliveryDate { get; set; }
        public int? IncoTermsId { get; set; }
        public int? QuotationId { get; set; }

        public virtual GlobalAirports Destination { get; set; }
        public virtual IncoTerms IncoTerms { get; set; }
        public virtual GlobalAirports Origin { get; set; }
        public virtual Quotation Quotation { get; set; }
        public virtual ICollection<CartonSpecs> CartonSpecs { get; set; }
    }
}
