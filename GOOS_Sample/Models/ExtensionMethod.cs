using System;

namespace GOOS_Sample.Models
{
    public static class ExtensionMethod
    {
        public static decimal GetDailyAmount(this Budgets budget)
        {
            var daysOfBudgets = DateTime.DaysInMonth(
                Convert.ToInt16(budget.YearMonth.Split('-')[0]),
                Convert.ToInt16(budget.YearMonth.Split('-')[1]));

            return budget.Amount / daysOfBudgets;
        }

        private static int GetOverlappingDays(Period period)
        {
            return new TimeSpan(period.EndDate.AddDays(1).Ticks - period.StartDate.Ticks).Days; 
        }

        public static decimal GetOverlappingAmount(this Budgets budget, Period period)
        {
            var dailyAmount = budget.GetDailyAmount();

            var daysOfPeriod = GetOverlappingDays(period);

            return dailyAmount * daysOfPeriod;
        }
    }
}