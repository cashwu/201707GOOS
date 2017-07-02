using System;

namespace GOOS_Sample.Models
{
    public static class ExtensionMethod
    {
        public static decimal GetOverlappingAmount(this Budgets budget, Period period)
        {
            return budget.GetDailyAmount() * budget.GetOverlappingDays(period);
        }

        public static decimal GetDailyAmount(this Budgets budget)
        {
            return budget.Amount / budget.GetDaysOfBudgetYearMonth();
        }

        private static int GetDaysOfBudgetYearMonth(this Budgets budget)
        {
            return DateTime.DaysInMonth(
                Convert.ToInt16(budget.YearMonth.Split('-')[0]),
                Convert.ToInt16(budget.YearMonth.Split('-')[1]));
        }

        private static int GetOverlappingDays(this Budgets budget, Period period)
        {
            var endBoundary = period.EndDate;

            if (endBoundary > LastDay(budget.YearMonth))
            {
                endBoundary = LastDay(budget.YearMonth);
            }

            var startBoundary = GetStartBoundary(budget, period);

            return new TimeSpan(endBoundary.AddDays(1).Ticks - startBoundary.Ticks).Days; 
        }

        private static DateTime LastDay(string yearMonth)
        {
            int daysInMonth = DaysInMonth(yearMonth);
            return DateTime.Parse($"{yearMonth}-{daysInMonth}");
        }

        private static int DaysInMonth(string yearMonth)
        {
            return DateTime.DaysInMonth(
                Convert.ToInt16(yearMonth.Split('-')[0]), 
                Convert.ToInt16(yearMonth.Split('-')[1]));
        }

        private static DateTime GetStartBoundary(Budgets budget, Period period)
        {
            var firstDay = budget.YearMonth.FirstDay();
            return period.StartDate < firstDay ? firstDay : period.StartDate;
        }

        private static DateTime FirstDay(this string yearMonth)
        {
            return DateTime.Parse($"{yearMonth}-01");
        }
    }
}