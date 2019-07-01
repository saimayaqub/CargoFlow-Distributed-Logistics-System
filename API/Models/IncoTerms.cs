using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class IncoTerms
    {
        public IncoTerms()
        {
            CargoDetail = new HashSet<CargoDetail>();
        }

        public int IncoTermsId { get; set; }
        public string IncoTermsAbbr { get; set; }
        public string IncoTermsDescription { get; set; }

        public virtual ICollection<CargoDetail> CargoDetail { get; set; }
    }
}
