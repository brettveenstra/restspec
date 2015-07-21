using System.Net.Http.Headers;
using TechTalk.SpecFlow;

namespace restspec
{
    [Binding]
    public class RequestHeaderStepDefinitions
    {
        private readonly HttpTestContext _context;
        public RequestHeaderStepDefinitions(HttpTestContext context)
        {
            _context = context;
        }

        [Given(@"I specify an accept header of '(.*)'")]
        public void GivenISpecifyAnAcceptHeaderOf(string mediaType)
        {
            _context.RequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
        }


    }
}