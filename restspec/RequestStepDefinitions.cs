using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }

        [When(@"I issue a '(.*)' request to '(.*)'")]
        public void WhenIIssueARequestTo(string httpMethod, string url)
        {
            var client = _context.GetHttpClient();
            _context.RequestMessage.RequestUri = IsAbsoluteUrl(url) ? new Uri(url) : new Uri(client.BaseAddress, url);
            _context.RequestMessage.Method = new HttpMethod(httpMethod);
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var task = client.SendAsync(_context.RequestMessage);
            Task.WaitAll(task);
            stopWatch.Stop();

            _context.TimeTaken = stopWatch.Elapsed;
            _context.ResponseMessage = task.Result;
        }



    }
}
