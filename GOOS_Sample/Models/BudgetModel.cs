using System;

namespace GOOS_Sample.Models
{
    public class BudgetModel
    {
        private readonly Budgets budget;
        private readonly Period period;

        public BudgetModel(Budgets budget, Period period)
        {
            this.budget = budget;
            this.period = period;
        }

        public decimal GetOverlappingAmount()
        {
            return GetDailyAmount() * GetOverlappingDays();
        }

        public decimal GetDailyAmount()
        {
            return budget.Amount / GetDaysOfBudgetYearMonth();
        }

        public bool IsCoveredByPeriod()
        {
            return string.Compare(budget.YearMonth, period.StartDateString, StringComparison.Ordinal) >= 0
                   && string.Compare(budget.YearMonth, period.EndDateString, StringComparison.Ordinal) <= 0;
        }

        private int GetDaysOfBudgetYearMonth()
        {
            return DaysInMonth(budget.YearMonth);
        }

        private int GetOverlappingDays()
        {
            var endBoundary = GetEndBoundary();
            var startBoundary = GetStartBoundary();

            return new TimeSpan(endBoundary.AddDays(1).Ticks - startBoundary.Ticks).Days;
        }

        private DateTime GetEndBoundary()
        {
            var lastDay = LastDay(budget.YearMonth);
            return period.EndDate > lastDay ? lastDay : period.EndDate;
        }

        private DateTime GetStartBoundary()
        {
            var firstDay = FirstDay(budget.YearMonth);
            return period.StartDate < firstDay ? firstDay : period.StartDate;
        }

        private DateTime LastDay(string yearMonth)
        {
            return DateTime.Parse($"{yearMonth}-{DaysInMonth(yearMonth)}");
        }

        private int DaysInMonth(string yearMonth)
        {
            return DateTime.DaysInMonth(
                Convert.ToInt16(yearMonth.Split('-')[0]),
                Convert.ToInt16(yearMonth.Split('-')[1]));
        }

        private DateTime FirstDay(string yearMonth)
        {
            return DateTime.Parse($"{yearMonth}-01");
        }
    }
}