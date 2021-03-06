﻿using System;
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
                AddBudget(model);
            }
            else
            {
                UpdateBudget(model, budget);
            }
        }

        private void UpdateBudget(BudgetAddViewModel model, Budgets budget)
        {
            budget.Amount = model.Amount;

            this.budgetRepository.Save(budget);

            var handler = this.Updated;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void AddBudget(BudgetAddViewModel model)
        {
            budgetRepository.Save(new Budgets
            {
                Amount = model.Amount,
                YearMonth = model.Month
            });

            var handler = this.Created;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Created;
        public event EventHandler Updated;

        public decimal TotalBudget(Period period)
        {
            return budgetRepository
                .ReadAll()
                .Select(a => new BudgetModel(a, period))
                .Where(a => a.IsCoveredByPeriod())
                .Sum(a => a.GetOverlappingAmount());
        }
    }
}