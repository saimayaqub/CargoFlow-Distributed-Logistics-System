using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Operator
    {
        public Operator()
        {
            Consignee = new HashSet<Consignee>();
            EmailContents = new HashSet<EmailContents>();
            Quotation = new HashSet<Quotation>();
        }

        public string OperatorId { get; set; }
        public string RevLogUserId { get; set; }
        public string Ntn { get; set; }
        public string CompanyName { get; set; }

        public virtual RevLogUser RevLogUser { get; set; }
        public virtual ICollection<Consignee> Consignee { get; set; }
        public virtual ICollection<EmailContents> EmailContents { get; set; }
        public virtual ICollection<Quotation> Quotation { get; set; }
    }
}
