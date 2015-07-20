using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Should;
using Should.Core.Assertions;
using TechTalk.SpecFlow;

namespace restspec
{

    public class TestContext
    {
        private static readonly WebRequestHandler WebRequestHandler = new WebRequestHandler
        {
            CachePolicy =
                            new HttpRequestCachePolicy(
                            HttpCacheAgeControl.MaxAgeAndMinFresh,
                            TimeSpan.FromMilliseconds(0),
                            TimeSpan.FromMilliseconds(0))
        };

        public HttpClient GetHttpClient()
        {

            return new HttpClient(WebRequestHandler)
            {
            };
        }

        public HttpRequestMessage RequestMessage { get; } 
        public HttpResponseMessage ResponseMessage { get; set; } 
    }

    [Binding]
    public class StepDefinitions
    {
        private readonly TestContext _testContext;
        public StepDefinitions(TestContext testContext)
        {
            _testContext = testContext;
        }

        [When(@"I issue a '(.*)' request to '(.*)'")]
        public void WhenIIssueARequestTo(string httpMethod, string url)
        {
            var client = _testContext.GetHttpClient();
            var task = client.SendAsync(new HttpRequestMessage(new HttpMethod(httpMethod), url));
            Task.WaitAll(task);
            _testContext.ResponseMessage = task.Result;
        }
         
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(int p0)
        {
            
        }

        [Then(@"the response should be valid JSON")]
        public void ThenTheResponseShouldBeValidJson()
        {
           
        }

    }
}
