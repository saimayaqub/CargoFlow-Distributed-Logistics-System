using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CargoStatusList
    {
        public CargoStatusList()
        {
            Quotation = new HashSet<Quotation>();
        }

        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Quotation> Quotation { get; set; }
    }
}
