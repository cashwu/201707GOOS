using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public interface IBudgetServices
    {
        void Create(BudgetAddViewModel model);
    }
}