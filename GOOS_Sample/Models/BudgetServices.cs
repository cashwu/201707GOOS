using System;
using System.Linq;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public class BudgetServices : IBudgetServices
    {
        private readonly IRepository<Budgets> budgetRepository;

        public BudgetServices(IRepository<Budgets> budgetRepository)
        {
            this.budgetRepository = budgetRepository;
        }

        public void Create(BudgetAddViewModel model)
        {
            var budget = this.budgetRepository.Read(a => a.YearMonth == model.Month);

            if (budget == null)
            {
                budgetRepository.Save(new Budgets
                {
                    Amount = model.Amount,
                    YearMonth = model.Month
                });

                var handler = this.Created;
                handler?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                budget.Amount = model.Amount;

                this.budgetRepository.Save(budget);

                var handler = this.Updated;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler Created;
        public event EventHandler Updated;

        public decimal TotalBudget(Period period)
        {
            var budgets = budgetRepository.ReadAll();
            var budget = budgets.ElementAt(0);

            var daysOfBudgets = DateTime.DaysInMonth(
                Convert.ToInt16(budget.YearMonth.Split('-')[0]),
                Convert.ToInt16(budget.YearMonth.Split('-')[1]));

            var dailyAmount = budget.Amount / daysOfBudgets;

            var daysOfPeriod = new TimeSpan(period.EndDate.AddDays(1).Ticks - period.StartDate.Ticks).Days;

            var result = dailyAmount * daysOfPeriod;

            return result;
        }
    }
}