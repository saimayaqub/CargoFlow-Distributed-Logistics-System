using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class RevLogUser
    {
        public RevLogUser()
        {
            Consignee = new HashSet<Consignee>();
            Customer = new HashSet<Customer>();
            Operator = new HashSet<Operator>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? MemberSince { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Consignee> Consignee { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }
    }
}
