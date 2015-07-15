using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace restspec
{
    public class StepDefinitions
    {
        [When(@"I issue a '(.*)' request to '(.*)'")]
        public void WhenIIssueARequestTo(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the response should be valid JSON")]
        public void ThenTheResponseShouldBeValidJSON()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
