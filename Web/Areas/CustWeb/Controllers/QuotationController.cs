using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.CustWeb.ViewModels;

namespace Web.Areas.CustWeb.Controllers
{
    [Serializable]
    public class QuotationController : Controller
    {
        public ActionResult Index()
        {
            var wizard = new QuotationWizardViewModel();
            wizard.Initialize();
            return View(wizard);
        }

        [HttpPost]
        
        public ActionResult Index(
            QuotationWizardViewModel wizard, 
            IStepViewModel step
        )
        {
            wizard.Steps[wizard.CurrentStepIndex] = step;
            string reqQueryStringNextOrPrev = "next";
            if (ModelState.IsValid)
            {            
                if (!string.IsNullOrEmpty(reqQueryStringNextOrPrev))
                {
                    wizard.CurrentStepIndex++;
                }
                else if (!string.IsNullOrEmpty(reqQueryStringNextOrPrev))
                {
                    wizard.CurrentStepIndex--;
                }
                else
                {
                    // TODO: we have finished: all the step partial
                    // view models have passed validation => map them
                    // back to the domain model and do some processing with
                    // the results
                    return Content("thanks for filling this form", "text/plain");
                }
            }
            else if (!string.IsNullOrEmpty(reqQueryStringNextOrPrev))
            {
                // Even if validation failed we allow the user to
                // navigate to previous steps
                wizard.CurrentStepIndex--;
            }
            return View(wizard);
        }

        [HttpPost]
        public ActionResult Step1(Step1ViewModel step1)
        {
            var model = new QuotationWizardViewModel

            {
                Step1 = (Step1ViewModel)step1
            };

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("Step2", model);
        }

        [HttpPost]
        public ActionResult Step2(Step2ViewModel step2, Step1ViewModel step1)
        {
            var model = new QuotationWizardViewModel
            {
                Step1 = step1,
                Step2 = step2
            };

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("Step3", model);
        }
    }

   
}