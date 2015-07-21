using System.Net;
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

        [Given(@"I specify an accept lanugage header of '(.*)'")]
        public void GivenISpecifyAnAcceptLanguageHeaderOf(string lauguage)
        {
            _context.RequestMessage.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(lauguage));
        }

        [Given(@"I specify an accept encoding header of '(.*)'")]
        public void GivenISpecifyAnAcceptEncodingHeaderOf(string encoding)
        {
            _context.RequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(encoding));
        }
         
    }
}