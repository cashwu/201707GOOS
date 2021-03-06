﻿using FluentAutomation;

namespace GOOS_SampleTests.PageObjects
{
    internal class BudgetQueryPage : PageObject<BudgetQueryPage>
    {
        public BudgetQueryPage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/budget/query";
        }

        public void Query(string startDate, string endDate)
        {
            I.Enter(startDate).In("#startDate")
                .Enter(endDate).In("#endDate")
                .Click("input[type=\"submit\"]");
        }

        public void ShouldDispalyAmount(decimal amount)
        {
            I.Assert.Text(amount.ToString("##.00")).In("#amount");
        }
    }
}