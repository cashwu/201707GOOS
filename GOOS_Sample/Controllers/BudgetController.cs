using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetServices budgetServices;

        public BudgetController(IBudgetServices budgetServices)
        {
            this.budgetServices = budgetServices;
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            budgetServices.Create(model);

            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}