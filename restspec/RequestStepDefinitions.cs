using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Should;
using Should.Core.Assertions;
using TechTalk.SpecFlow;

namespace restspec
{
    [Binding]
    public class RequestStepDefinitions
    {
        private readonly HttpTestContext _context;
        public RequestStepDefinitions(HttpTestContext context)
        {
            _context = context;
        }

        [When(@"I issue a '(.*)' request to '(.*)'")]
        public void WhenIIssueARequestTo(string httpMethod, string url)
        {
            var client = _context.GetHttpClient();
            _context.RequestMessage.RequestUri = new Uri(client.BaseAddress, url);
            _context.RequestMessage.Method = new HttpMethod(httpMethod);
            var task = client.SendAsync(_context.RequestMessage);
            Task.WaitAll(task);
            _context.ResponseMessage = task.Result;
        }




    }
}
