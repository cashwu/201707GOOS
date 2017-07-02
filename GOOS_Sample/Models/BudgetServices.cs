using System;
using System.Collections.Generic;
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
            return budgetRepository
                .ReadAll()
                .Where(a => IsBetweenPeriod(period, a))
                .Sum(a => a.GetOverlappingAmount(period));
        }

        private bool IsBetweenPeriod(Period period, Budgets budgets)
        {
            return string.Compare(budgets.YearMonth, period.StartDateString, StringComparison.Ordinal) >= 0
                   && string.Compare(budgets.YearMonth, period.EndDateString, StringComparison.Ordinal) <= 0;
        }
    }
}