using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public int? BookingId { get; set; }
        public string Etd { get; set; }
        public string Eta { get; set; }
        public string TransShipmentPort1 { get; set; }
        public string TransShipmentPort2 { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
