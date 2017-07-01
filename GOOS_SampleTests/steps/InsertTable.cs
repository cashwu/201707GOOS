using GOOS_SampleTests.DataModelsForTest;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    public sealed class InsertTable
    {
        [Given(@"Budget table existed budget")]
        public void GivenBudgetTableExistedBudget(Table table)
        {
            //same with BudgetCreateSteps
            var budgets = table.CreateSet<Budgets>();
            using (var dbcontext = new NorthwindEntitiesForTest())
            {
                dbcontext.Budgets.AddRange(budgets);
                dbcontext.SaveChanges();
            }
        }
    }
}