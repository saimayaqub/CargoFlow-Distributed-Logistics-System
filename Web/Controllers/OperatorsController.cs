using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.APIMessages;
using Web.Helper;

namespace Web.Controllers
{
    public class OperatorsController : Controller
    {
        // GET: Operators
        public ActionResult Index()
        {
            try
            {
                List<Operator> resultList = new List<Operator>();
                var operators = GetEntityHelper.GetEntityList("operator");
                return View(operators);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Operators/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Operator objOperator = new Operator();
                objOperator = GetEntityHelper.GetEntityDetailsById(id, objOperator.GetType().Name);
                return View(objOperator);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }              

        // GET: Operators/Create
        //Will open the form to enter new operator data
        public ActionResult Create()
        {            
            System.Diagnostics.Debug.WriteLine("Create Operator form was invoked..");
            return View();
        }

        // POST: Operators/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Operator op)
        {
            try
            {
                Helper.CrudHelper.ProcessCrud(-1,op, "create","Operators"); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RevLog Error while creation of an operator: " + ex.Message);
                //If you have reached this far, this means there occurred some error. Show the same view rather than redirecting to index.
                return View();
            }
        }

        // GET: Operators/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(GetEntityHelper.GetEntityDetailsById(id, "operator"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Operators/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm]Operator op)
        {
            try
            {
                Helper.CrudHelper.ProcessCrud(id, op, "update","Operators");
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Details", new { op.OperatorId }); //Raises UnsupportedMediaTypeException: No MediaTypeFormatter is available to read an object of type 'Operator' from content with media type 'application/problem+json'.
                //return RedirectToAction("Details", op); //Raises UnsupportedMediaTypeException: No MediaTypeFormatter is available to read an object of type 'Operator' from content with media type 'application/problem+json'.
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RevLog Error while creation of an operator: " + ex.Message);
                throw ex;
            }
        }

        // GET: Operators/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(GetEntityHelper.GetEntityDetailsById(id, entityType: "operators"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Operators/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Helper.CrudHelper.ProcessCrud(id, null, "delete", "Operators"); //we dont require any object of Operator type here, so its safe to pass null
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RevLog Error while creation of an operator: " + ex.Message);
                return View();
            }           
        }
    }
}