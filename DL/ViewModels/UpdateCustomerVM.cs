using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.ViewModels
{
    public class UpdateCustomerVM
    {
        public UpdateCustomerVM()
        {
        }
        public int CustomerId { get; set; }
        public int RevLogUserId { get; set; }

        public virtual RevLogUser RevLogUser { get; set; }
    }


}
