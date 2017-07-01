using System;
using System.Linq;

namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budgets>
    {
        public void Save(Budgets budget)
        {
            using (var db = new NorthwindEntities())
            {
                var budgetFromDB = db.Budgets.FirstOrDefault(a => a.YearMonth == budget.YearMonth);

                if (budgetFromDB == null)
                {
                    db.Budgets.Add(budget);
                }
                else
                {
                    budgetFromDB.Amount = budget.Amount;
                }

                db.SaveChanges();
            }
        }

        public Budgets Read(Func<Budgets, bool> predicate)
        {
            using (var db = new NorthwindEntities())
            {
                return db.Budgets.FirstOrDefault(predicate);
            }
        }
    }
}