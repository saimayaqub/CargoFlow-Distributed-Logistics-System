using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class Awbinventory
    {
        public int Id { get; set; }
        public string Awbnumber { get; set; }
        public DateTime? DateAcquired { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
