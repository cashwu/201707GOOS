using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using GOOS_SampleTests.DataModelsForTest;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.steps.Common
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        [Scope(Tag = "web")]
        public void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            CleanTableByTags();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            CleanTableByTags();
        }

        public static void CleanTableByTags()
        {

            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));

            if (!tags.Any())
            {
                return;
            }

            using (var dbcontext = new NorthwindEntitiesForTest())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
                }

                dbcontext.SaveChangesAsync();
            }
        }
    }
}
