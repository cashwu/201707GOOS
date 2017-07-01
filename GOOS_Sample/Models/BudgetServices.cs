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
            var budget = new Budgets
            {
                Amount = model.Amount,
                YearMonth = model.Month
            };

            budgetRepository.Save(budget);
            //using (var db = new NorthwindEntities())
            //{
            //    var budget = new Budgets
            //    {
            //        Amount = model.Amount,
            //        YearMonth = model.Month
            //    };

            //    db.Budgets.Add(budget);
            //    db.SaveChanges();
            //}
        }
    }
}