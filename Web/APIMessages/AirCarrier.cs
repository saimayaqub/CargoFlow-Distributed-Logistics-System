using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class AirCarrier
    {
        public AirCarrier()
        {
            AirFreightRates = new HashSet<AirFreightRates>();
            OriginCharges = new HashSet<OriginCharges>();
        }

        public int AirCarrierId { get; set; }
        public string CarrierName { get; set; }
        public string RepEmail { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<AirFreightRates> AirFreightRates { get; set; }
        public virtual ICollection<OriginCharges> OriginCharges { get; set; }
    }
}
