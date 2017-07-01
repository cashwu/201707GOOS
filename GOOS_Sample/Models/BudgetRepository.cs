﻿namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budgets>
    {
        public void Save(Budgets budget)
        {
            using (var db = new NorthwindEntities())
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
            }
        }
    }
}