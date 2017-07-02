using System;

namespace GOOS_Sample.Models
{
    public class Period
    {
        public Period(DateTime startDateTime, DateTime endDateTime)
        {
            this.StartDate = startDateTime;
            this.EndDate = endDateTime;
        }

        public DateTime EndDate { get; }
        public DateTime StartDate { get; }
        public string StartDateString => StartDate.ToString("yyyy-MM");
        public string EndDateString => EndDate.ToString("yyyy-MM");
    }
}