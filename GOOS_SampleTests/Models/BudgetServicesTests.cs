﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using OpenQA.Selenium.Remote;

namespace GOOS_SampleTests.Models
{
    [TestClass]
    public class BudgetServicesTests
    {
        private BudgetServices budgetServices;
        private IRepository<Budgets> budgetRepositoryStub = Substitute.For<IRepository<Budgets>>();

        [TestMethod]
        public void CreateTest_should_invoke_repository_one_time()
        {
            budgetServices = new BudgetServices(budgetRepositoryStub);

            var model = new BudgetAddViewModel
            {
                Amount = 2000,
                Month = "2017-02"
            };

            budgetServices.Create(model);

            budgetRepositoryStub.Received().Save(Arg.Is<Budgets>(a => a.Amount == 2000 && a.YearMonth == "2017-02"));
        }
    }
}