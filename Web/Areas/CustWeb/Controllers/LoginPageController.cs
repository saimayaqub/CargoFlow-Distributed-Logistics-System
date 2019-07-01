using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.CustWeb.ViewModels;

namespace Web.Areas.CustWeb.Controllers
{
    public class LoginPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(LoginPageVM model)
        {
            //code to login user to application...
            return View(model);
        }
    }
}