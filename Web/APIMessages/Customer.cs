﻿using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class Customer
    {
        public Customer()
        {
            Consignee = new HashSet<Consignee>();
            Quotation = new HashSet<Quotation>();
        }

        public int CustomerId { get; set; }
        public int RevLogUserId { get; set; }
        public DateTime? CustomerSince { get; set; }

        public virtual RevLogUser RevLogUser { get; set; }
        public virtual ICollection<Consignee> Consignee { get; set; }
        public virtual ICollection<Quotation> Quotation { get; set; }
    }
}
