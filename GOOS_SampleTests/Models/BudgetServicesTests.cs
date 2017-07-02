using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
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
            InjectSutbToBudgetService();

            var model = new BudgetAddViewModel
            {
                Amount = 2000,
                Month = "2017-02"
            };

            var wasCreate = false;

            budgetServices.Created += (sender, args) => { wasCreate = true; };
            budgetServices.Create(model);

            budgetRepositoryStub.Received().Save(Arg.Is<Budgets>(a => a.Amount == 2000 && a.YearMonth == "2017-02"));
            Assert.IsTrue(wasCreate);
        }

        [TestMethod()]
        public void CreateTest_when_exist_record_should_update_budget()
        {
            InjectSutbToBudgetService();

            var budgetFromDb = new Budgets { Amount = 999, YearMonth = "2017-02" };

            budgetRepositoryStub.Read(Arg.Any<Func<Budgets, bool>>())
                .ReturnsForAnyArgs(budgetFromDb);

            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };

            var wasCreate = false;
            budgetServices.Updated += (sender, args) => { wasCreate = true; };

            this.budgetServices.Create(model);

            budgetRepositoryStub.Received()
                .Save(Arg.Is<Budgets>(x => x == budgetFromDb && x.Amount == 2000));

            Assert.IsTrue(wasCreate);
        }

        [TestMethod]
        public void TotalBudgetTest_Period_of_single_month()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets
                    {
                        YearMonth = "2017-04",
                        Amount = 9000
                    }
                });

            AssertTotalAmount(3000, this.budgetServices.TotalBudget(
                new Period(
                    new DateTime(2017, 4, 5),
                    new DateTime(2017, 4, 14))));
        }

        [TestMethod]
        public void TotalBudgetTest_Period_StartDate_over_single_month_but_only_one_month_budget()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets
                    {
                        YearMonth = "2017-04",
                        Amount = 9000
                    }
                });

            AssertTotalAmount(3000, this.budgetServices.TotalBudget(
                new Period(
                    new DateTime(2017, 3, 5),
                    new DateTime(2017, 4, 10))));
        }

        [TestMethod]
        public void TotalBudgetTest_Period_EndDate_over_single_month_but_only_one_month_budget()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets
                    {
                        YearMonth = "2017-04",
                        Amount = 9000
                    }
                });

            AssertTotalAmount(3000, this.budgetServices.TotalBudget(
                new Period(
                    new DateTime(2017, 4, 21),
                    new DateTime(2017, 5, 10))));
        }

        [TestMethod]
        public void TotalBudgetTest_Period_over_single_month_but_only_one_month_budget()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets
                    {
                        YearMonth = "2017-04",
                        Amount = 9000
                    }
                });

            AssertTotalAmount(9000, this.budgetServices.TotalBudget(
                new Period(
                    new DateTime(2017, 3, 21),
                    new DateTime(2017, 5, 10))));
        }

        [TestMethod]
        public void TotalBudgetTest_Period_StartDate_over_month_when_two_months_budget()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets { YearMonth = "2017-03", Amount = 3100 },
                    new Budgets { YearMonth = "2017-04", Amount = 9000 }
                });

            AssertTotalAmount(10000, this.budgetServices.TotalBudget(
                new Period(
                    new DateTime(2017, 3, 22),
                    new DateTime(2017, 4, 30))));
        }

        [TestMethod]
        public void TotalBudgetTest_Period_EndDate_over_month_when_two_months_budget()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets { YearMonth = "2017-04", Amount = 9000 },
                    new Budgets { YearMonth = "2017-05", Amount = 3100 },
                });

            AssertTotalAmount(9500, this.budgetServices.TotalBudget(new Period(new DateTime(2017, 4, 1), new DateTime(2017, 5, 5))));
        }

        [TestMethod]
        public void TotalBudgetTest_Period_over_month_when_3_months_budget()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets { YearMonth = "2017-03", Amount = 6200 },
                    new Budgets { YearMonth = "2017-04", Amount = 9000 },
                    new Budgets { YearMonth = "2017-05", Amount = 3100 },
                });

            AssertTotalAmount(11500, this.budgetServices.TotalBudget(new Period(new DateTime(2017, 3, 22), new DateTime(2017, 5, 5))));
        }

        [TestMethod]
        public void TotalBudgetTest_budget_without_overlapping_with_period()
        {
            InjectSutbToBudgetService();

            budgetRepositoryStub.ReadAll()
                .ReturnsForAnyArgs(new List<Budgets>
                {
                    new Budgets
                    {
                        YearMonth = "2018-04",
                        Amount = 9000
                    }
                });

            AssertTotalAmount(0, this.budgetServices.TotalBudget(
                new Period(
                    new DateTime(2017, 3, 22),
                    new DateTime(2017, 4, 30))));
        }

        private void InjectSutbToBudgetService()
        {
            this.budgetServices = new BudgetServices(budgetRepositoryStub);
        }

        private void AssertTotalAmount(int expected, decimal amount)
        {
            amount.ShouldBeEquivalentTo(expected);
        }
    }
}
