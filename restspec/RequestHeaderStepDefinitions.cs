using System.Linq;
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

        [Given(@"an accept header of '(.*)'")]
        public void GivenISpecifyAnAcceptHeaderOf(string mediaType)
        {
            foreach (var result in mediaType.Split(',').Select(x => x.Trim()))
            {
                _context.RequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(result));
            }
        }

        [Given(@"an accept lanugage header of '(.*)'")]
        public void GivenISpecifyAnAcceptLanguageHeaderOf(string lauguage)
        {
            foreach (var result in lauguage.Split(',').Select(x => x.Trim()))
            {
                _context.RequestMessage.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(result));
            }
        }

        [Given(@"an accept encoding header of '(.*)'")]
        public void GivenISpecifyAnAcceptEncodingHeaderOf(string encoding)
        {
            foreach (var result in encoding.Split(',').Select(x => x.Trim()))
            {
                _context.RequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(result));
            }

        }
         
    }
}