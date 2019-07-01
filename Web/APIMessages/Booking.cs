﻿using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetail = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        public int? QuotationId { get; set; }
        public DateTime? DateOfBooking { get; set; }
        public string Awbnumber { get; set; }

        public virtual Quotation Quotation { get; set; }
        public virtual ICollection<BookingDetail> BookingDetail { get; set; }
    }
}