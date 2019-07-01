using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class Consignee
    {
        public int ConsigneeId { get; set; }
        public int RevLogUserId { get; set; }
        public DateTime? ConsigneeSince { get; set; }
        public int? ConsigneeOf { get; set; }
        public int? OperatorId { get; set; }

        public virtual Customer ConsigneeOfNavigation { get; set; }
        public virtual Operator Operator { get; set; }
        public virtual RevLogUser RevLogUser { get; set; }
    }
}
