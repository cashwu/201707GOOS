using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_SampleTests.DataModelsForTest;
using GOOS_SampleTests.steps.Common;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    public class BudgetControllerSteps
    {
        private BudgetController _budgetController;
        private readonly InsertTable insertTable = new InsertTable();

        [BeforeScenario]
        public void BeforeScenario()
        {
            this._budgetController = Hooks.UnityContainer.Resolve<BudgetController>();
        }

        [When(@"add a budget")]
        public void WhenAddABudget(Table table)
        {
            var model = table.CreateInstance<BudgetAddViewModel>();
            var result = _budgetController.Add(model);
            ScenarioContext.Current.Set<ActionResult>(result);
        }
        
        [Then(@"ViewBag should have a message for adding successfully")]
        public void ThenViewBagShouldHaveAMessageForAddingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetAddingSuccessfullyMessage());
        }

        private static string GetAddingSuccessfullyMessage()
        {
            return "added successfully";
        }

        [Then(@"it should exist a budget record in budget table")]
        public void ThenItShouldExistABudgetRecordInBudgetTable(Table table)
        {
            using (var db = new NorthwindEntitiesForTest())
            {
                var budget = db.Budgets.FirstOrDefault();
                budget.Should().NotBeNull();
                table.CompareToInstance(budget);
            }
        }

        [Then(@"ViewBag should have a message for updated successfully")]
        public void ThenViewBagShouldHaveAMessageForUpdatedSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetUpdatingSuccessfullyMessage());
        }

        private static string GetUpdatingSuccessfullyMessage()
        {
            return "updated successfully";
        }

        [When(@"query")]
        public void WhenQuery(Table table)
        {
            var model = table.CreateInstance<BudgetQueryViewModel>();
            var result = this._budgetController.Query(model);
            ScenarioContext.Current.Set<ActionResult>(result);
        }

        [Then(@"ViewData\.Model should be")]
        public void ThenViewData_ModelShouldBe(Table table)
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            var model = result.Model as BudgetQueryViewModel;
            table.CompareToInstance(model);
        }
    }
}
