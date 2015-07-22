using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Should;
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

        [Then(@"the status code should be '(.*)'")]
        public void ThenTheResultShouldBe(int statusCode)
        {
            _context.ResponseMessage.StatusCode.ShouldEqual((HttpStatusCode)statusCode);
        }

        [Then(@"the content should be valid JSON")]
        public void ThenTheResponseShouldBeValidJson()
        {
            JsonConvert.DeserializeObject(_context.ResponseContent);
        }

        [Then(@"the response should be '(.*)' compressed")]
        public void ThenTheResponseShouldBeGzipCompressed(string compressionMethod)
        {

            switch (compressionMethod.Trim().ToLowerInvariant())
            {
                case "gzip":
                    _context.DecompressionMethod.ShouldEqual(DecompressionMethods.GZip);
                    break;
                case "deflate":
                    _context.DecompressionMethod.ShouldEqual(DecompressionMethods.Deflate);
                    break;
                case "none":
                    _context.DecompressionMethod.ShouldEqual(DecompressionMethods.None);
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} is not a valid compression method", compressionMethod));
            }

        }
   

        [Then(@"the content type header should be '(.*)'")]
        public void ThenTheContentTypeHeaderShouldBe(string mediaType)
        {
            _context.ResponseMessage.Content.Headers.ContentType.MediaType.ShouldEqual(mediaType);
        }

        [Then(@"the content encoding header should contain '(.*)'")]
        public void ThenTheContentEncodingHeaderShouldBe(string encoding)
        {
            _context.ResponseMessage.Content.Headers.ContentEncoding.ShouldContain(encoding);
        }

    }
}