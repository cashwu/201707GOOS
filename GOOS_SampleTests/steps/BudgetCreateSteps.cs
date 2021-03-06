﻿using System;
using FluentAutomation;
using GOOS_SampleTests.DataModelsForTest;
using GOOS_SampleTests.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    [Scope(Feature = "BudgetCreate")]
    public class BudgetCreateSteps : FluentTest
    {
        private readonly BudgetCreatePage _budgetCreatePage;

        public BudgetCreateSteps()
        {
            _budgetCreatePage = new BudgetCreatePage(this);
        }

        [Given(@"go to adding budget page")]
        public void GivenGoToAddingBudgetPage()
        {
            _budgetCreatePage.Go();
        }
        
        [When(@"I add a buget (.*) for ""(.*)""")]
        public void WhenIAddABugetFor(int amount, string yearMonth)
        {
            this._budgetCreatePage
                .Amount(amount)
                .Month(yearMonth)
                .AddBudget();
        }
        
        [Then(@"it should dispaly ""(.*)""")]
        public void ThenItShouldDispaly(string message)
        {
            this._budgetCreatePage.ShouldDisplay(message);
        }
    }
}
