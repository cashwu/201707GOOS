using System;
using GOOS_Sample.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using NSubstitute;

namespace GOOS_SampleTests.Controllers
{
    [TestClass]
    public class BudgetControllerTests
    {
        private BudgetController _budgetController;
        private IBudgetServices budgetServiceStub = Substitute.For<IBudgetServices>();

        [TestMethod]
        public void AddTest_add_budget_successfully_should_invoke_budgetService_Create_one_time()
        {
            _budgetController = new BudgetController(budgetServiceStub);
            var model = new BudgetAddViewModel
            {
                Amount = 2000,
                Month = "2017-02"
            };

            _budgetController.Add(model);

            budgetServiceStub.Received()
                .Create(Arg.Is<BudgetAddViewModel>(x => x.Amount == 2000 && x.Month == "2017-02"));
        }
    }
}
