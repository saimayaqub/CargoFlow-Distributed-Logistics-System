using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CustWeb.Controllers
{
    [Area("CustWeb")]
    public class CustProfileController : Controller
    {
        // GET: CustProfile
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: CustProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                // show customer's dashboard

                //return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                //return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustProfile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return View();
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}