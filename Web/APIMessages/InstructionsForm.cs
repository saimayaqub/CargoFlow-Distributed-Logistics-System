using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class InstructionsForm
    {
        public int InstructionsFormId { get; set; }
        public int? QuotationId { get; set; }
        public string ShipperAddress { get; set; }
        public string NotifyParty { get; set; }
        public string MarksAndNumber { get; set; }
        public string FormEnumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string Commodity { get; set; }
        public string Description { get; set; }
        public string ApproxWeight { get; set; }
        public int? TotalCartonsCount { get; set; }
        public DateTime? Date { get; set; }

        public virtual Quotation Quotation { get; set; }
    }
}
