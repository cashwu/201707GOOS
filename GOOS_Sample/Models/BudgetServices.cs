using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public class BudgetServices : IBudgetServices
    {
        public void Create(BudgetAddViewModel model)
        {
            using (var db = new NorthwindEntities())
            {
                var budget = new Budgets
                {
                    Amount = model.Amount,
                    YearMonth = model.Month
                };

                db.Budgets.Add(budget);
                db.SaveChanges();
            }
        }
    }
}