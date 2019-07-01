using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class SuperAdmin
    {
        public int SuperAdminId { get; set; }
        public int? RevLogUserId { get; set; }
        public DateTime? AdminSince { get; set; }
    }
}
