﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Exercise11SpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class IrisdataFeature : object, Xunit.IClassFixture<IrisdataFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "irisdata.feature"
#line hidden
        
        public IrisdataFeature(IrisdataFeature.FixtureData fixtureData, Exercise11SpecFlow_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "irisdata", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Calculate statistics")]
        [Xunit.TraitAttribute("FeatureTitle", "irisdata")]
        [Xunit.TraitAttribute("Description", "Calculate statistics")]
        [Xunit.TraitAttribute("Category", "DataSource:irisR.csv")]
        [Xunit.InlineDataAttribute("setosa", "sepal_length", "min", "4.30", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "sepal_length", "max", "5.80", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "sepal_length", "avg", "5.01", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "sepal_width", "min", "2.30", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "sepal_width", "max", "4.40", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "sepal_width", "avg", "3.42", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "petal_length", "min", "1.00", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "petal_length", "max", "1.90", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "petal_length", "avg", "1.46", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "petal_width", "min", "0.10", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "petal_width", "max", "0.60", new string[0])]
        [Xunit.InlineDataAttribute("setosa", "petal_width", "avg", "0.24", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "sepal_length", "min", "4.90", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "sepal_length", "max", "7.00", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "sepal_length", "avg", "5.94", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "sepal_width", "min", "2.00", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "sepal_width", "max", "3.40", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "sepal_width", "avg", "2.77", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "petal_length", "min", "3.00", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "petal_length", "max", "5.10", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "petal_length", "avg", "4.26", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "petal_width", "min", "1.00", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "petal_width", "max", "1.80", new string[0])]
        [Xunit.InlineDataAttribute("versicolor", "petal_width", "avg", "1.33", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "sepal_length", "min", "4.90", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "sepal_length", "max", "7.90", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "sepal_length", "avg", "6.59", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "sepal_width", "min", "2.20", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "sepal_width", "max", "3.80", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "sepal_width", "avg", "2.97", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "petal_length", "min", "4.50", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "petal_length", "max", "6.90", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "petal_length", "avg", "5.55", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "petal_width", "min", "1.40", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "petal_width", "max", "2.50", new string[0])]
        [Xunit.InlineDataAttribute("virginica", "petal_width", "avg", "2.03", new string[0])]
        public virtual void CalculateStatistics(string species, string property, string type, string result, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DataSource:irisR.csv"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("species", species);
            argumentsOfScenario.Add("property", property);
            argumentsOfScenario.Add("type", type);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate statistics", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
    testRunner.Given(string.Format("species is {0}", species), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
    testRunner.Given(string.Format("property is {0}", property), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
    testRunner.When(string.Format("we require the {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
    testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                IrisdataFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                IrisdataFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
