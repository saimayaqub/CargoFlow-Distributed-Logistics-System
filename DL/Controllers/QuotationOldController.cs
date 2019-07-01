    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.Infrastructure;
using DL.Models;
using DL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DL.Controllers
{
    public class QuotationOldController : Controller
    {
        private IQuotationRepository QuotationRepository;

        public QuotationOldController()
        {
            this.QuotationRepository = new QuotationRepository(new DatabaseFactory());
            
        }

        public QuotationOldController(IQuotationRepository QuotationRepository)
        {
            this.QuotationRepository = QuotationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}