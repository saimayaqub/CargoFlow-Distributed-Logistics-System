using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class CurrencyList
    {
        public int CurrencyId { get; set; }
        public string CurrencyAbbr { get; set; }
        public string CurrencyName { get; set; }
    }
}
