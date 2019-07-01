using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class SuperAdmin
    {
        public int SuperAdminId { get; set; }
        public string RevLogUserId { get; set; }
        public DateTime? AdminSince { get; set; }
    }
}
