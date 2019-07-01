using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CurrencyList
    {
        public int CurrencyId { get; set; }
        public string CurrencyAbbr { get; set; }
        public string CurrencyName { get; set; }
    }
}
