using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using SpecFlow.Assist.Dynamic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace irisdataSpec.StepDefinitions
{
    [Binding]
    public sealed class Irisdatasteps
    {
        private readonly ScenarioContext _scenarioContext;
        private double _result;

        private string _species;
        private string _prop;

        private readonly Exercise11 _excercise11 = new Exercise11();
        
        public Irisdatasteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"species is (.*)")]
        public void GivenSpeciesIsSpecies(string species)
        {
            _species = species;
        }

        [Given(@"property is (.*)")]
        public void GivenPropertyIsProperty(string property)
        {
            _prop = property;
        }

        [When(@"we require the (.*)")]
        public void WhenWeRequireTheType(string type)
        {
            _result = _excercise11.calc(_species, _prop, type);
            Console.WriteLine(type);
            Console.WriteLine(_result);
            
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeResult(double result)
        {
            _result.Should().Be(result);
        }

    }

}