using TechTalk.SpecFlow;

namespace restspec
{
    [Binding]
    public class ResponseStepDefinitions
    {
        private readonly HttpTestContext _context;
        public ResponseStepDefinitions(HttpTestContext context)
        {
            _context = context;
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