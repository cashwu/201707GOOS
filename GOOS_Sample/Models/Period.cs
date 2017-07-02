using System;

namespace GOOS_Sample.Models
{
    public class Period
    {
        private readonly DateTime startDateTime;
        private readonly DateTime endDateTime;

        public Period(DateTime startDateTime, DateTime endDateTime)
        {
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
        }
    }
}