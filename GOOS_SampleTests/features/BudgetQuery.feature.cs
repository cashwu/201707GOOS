﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GOOS_SampleTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class BudgetQueryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BudgetQuery.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BudgetQuery", null, ProgrammingLanguage.CSharp, new string[] {
                        "web"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "BudgetQuery")))
            {
                GOOS_SampleTests.Features.BudgetQueryFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Query budget within single month")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BudgetQuery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CleanBudgets")]
        public virtual void QueryBudgetWithinSingleMonth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Query budget within single month", new string[] {
                        "CleanBudgets"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
        testRunner.Given("go to query budget page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Amount",
                        "YearMonth"});
            table1.AddRow(new string[] {
                        "30000",
                        "2017-04"});
#line 8
        testRunner.And("Budget table existed budget", ((string)(null)), table1, "And ");
#line 11
        testRunner.When("query from \"2017-04-05\" to \"2017-04-14\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
        testRunner.Then("show budget 10000.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Query budget within 3 month")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BudgetQuery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CleanBudgets")]
        public virtual void QueryBudgetWithin3Month()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Query budget within 3 month", new string[] {
                        "CleanBudgets"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
        testRunner.Given("go to query budget page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Amount",
                        "YearMonth"});
            table2.AddRow(new string[] {
                        "6200",
                        "2017-03"});
            table2.AddRow(new string[] {
                        "9000",
                        "2017-04"});
            table2.AddRow(new string[] {
                        "3100",
                        "2017-05"});
#line 17
        testRunner.And("Budget table existed budget", ((string)(null)), table2, "And ");
#line 22
        testRunner.When("query from \"2017-03-22\" to \"2017-05-05\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
        testRunner.Then("show budget 11500.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Query budget within 3 month, there are 2 month out of period")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BudgetQuery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CleanBudgets")]
        public virtual void QueryBudgetWithin3MonthThereAre2MonthOutOfPeriod()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Query budget within 3 month, there are 2 month out of period", new string[] {
                        "CleanBudgets"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
        testRunner.Given("go to query budget page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Amount",
                        "YearMonth"});
            table3.AddRow(new string[] {
                        "555",
                        "2017-02"});
            table3.AddRow(new string[] {
                        "6200",
                        "2017-03"});
            table3.AddRow(new string[] {
                        "9000",
                        "2017-04"});
            table3.AddRow(new string[] {
                        "3100",
                        "2017-05"});
            table3.AddRow(new string[] {
                        "1234",
                        "2017-06"});
#line 28
        testRunner.And("Budget table existed budget", ((string)(null)), table3, "And ");
#line 35
        testRunner.When("query from \"2017-03-22\" to \"2017-05-05\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
        testRunner.Then("show budget 11500.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
