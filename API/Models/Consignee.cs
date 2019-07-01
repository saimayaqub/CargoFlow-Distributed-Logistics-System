using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Consignee
    {
        public int ConsigneeId { get; set; }
        public string RevLogUserId { get; set; }
        public DateTime? ConsigneeSince { get; set; }
        public int? ConsigneeOf { get; set; }
        public string OperatorId { get; set; }

        public virtual Customer ConsigneeOfNavigation { get; set; }
        public virtual Operator Operator { get; set; }
        public virtual AspNetUsers RevLogUser { get; set; }
        public virtual RevLogUser RevLogUserNavigation { get; set; }
    }
}
