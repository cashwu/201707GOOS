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
            budgetServices.Created += (sender, e) => { ViewBag.Message = "added successfully"; };
            budgetServices.Updated += (sender, e) => { ViewBag.Message = "updated successfully"; };

            budgetServices.Create(model);
            //ViewBag.Message = "added successfully";
            return View(model);
        }

        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query(BudgetQueryViewModel model)
        {
            model.Amount = budgetServices.TotalBudget(
                new Period(
                    DateTime.Parse(model.StartDate), 
                    DateTime.Parse(model.EndDate)));

            return View(model);
        }
    }
}