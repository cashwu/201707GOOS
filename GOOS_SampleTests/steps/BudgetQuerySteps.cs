using System;
using FluentAutomation;
using GOOS_SampleTests.PageObjects;
using TechTalk.SpecFlow;
namespace GOOS_SampleTests.steps
{
    [Binding]
    public class BudgetQuerySteps : FluentTest
    {
        private readonly BudgetQueryPage bugBudgetQueryPage;

        public BudgetQuerySteps()
        {
            bugBudgetQueryPage = new BudgetQueryPage(this);
        }

        [Given(@"go to query budget page")]
        public void GivenGoToQueryBudgetPage()
        {
            this.bugBudgetQueryPage.Go();
        }
        
        [When(@"query from ""(.*)"" to ""(.*)""")]
        public void WhenQueryFromTo(string startDate, string endDate)
        {
            this.bugBudgetQueryPage.Query(startDate, endDate);
        }
        
        [Then(@"show budget (.*)")]
        public void ThenShowBudget(Decimal amount)
        {
            this.bugBudgetQueryPage.ShouldDispalyAmount(amount);
        }
    }
}
