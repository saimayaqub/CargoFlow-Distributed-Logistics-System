using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Customer
    {
        public Customer()
        {
           // Consignee = new HashSet<Consignee>();
        }

        //public Customer(AspNetUsers anAspNetUser)
        //{
        //    RevLogUser = anAspNetUser;
        //}

        public int CustomerId { get; set; }
        public string RevLogUserId { get; set; }
        public DateTime? CustomerSince { get; set; }

        public virtual AspNetUsers RevLogUser { get; set; }
        public virtual ICollection<Consignee> Consignee { get; set; }
    }
}
