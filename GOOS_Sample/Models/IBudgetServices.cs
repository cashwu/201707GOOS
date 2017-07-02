using System;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public interface IBudgetServices
    {
        void Create(BudgetAddViewModel model);
        event EventHandler Created;
        event EventHandler Updated;
        decimal TotalBudget(Period period);
    }
}