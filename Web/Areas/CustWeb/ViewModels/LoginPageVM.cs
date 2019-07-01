using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.CustWeb.ViewModels
{
    public class LoginPageVM
    {
        [Required(ErrorMessage = "Are you really trying to login without entering username?")]
        [DisplayName("Username/e-mail")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password:)")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Stay logged in when browser is closed")]
        public bool RememberMe { get; set; }
    }
}
