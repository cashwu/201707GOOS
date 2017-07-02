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

        private static int GetOverlappingDays(Budgets budget, Period period)
        {
            var endBoundary = period.EndDate.AddDays(1);
            var startBoundary = period.StartDate;

            DateTime yearMonthFirstDate = budget.YearMonth.FirstDay();

            if (startBoundary < yearMonthFirstDate)
            {
                startBoundary = yearMonthFirstDate;
            }

            return new TimeSpan(endBoundary.Ticks - startBoundary.Ticks).Days; 
        }

        public static decimal GetOverlappingAmount(this Budgets budget, Period period)
        {
            var dailyAmount = budget.GetDailyAmount();

            var daysOfPeriod = GetOverlappingDays(budget, period);

            return dailyAmount * daysOfPeriod;
        }

        private static DateTime FirstDay(this string yearMonth)
        {
            return DateTime.Parse($"{yearMonth}-01");
        }
    }
}