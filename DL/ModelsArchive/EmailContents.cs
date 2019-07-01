using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class EmailContents
    {
        public int FormatId { get; set; }
        public string Category { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Signature { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Operator Operator { get; set; }
    }
}
