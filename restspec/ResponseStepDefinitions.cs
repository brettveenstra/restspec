using System;
using System.IO;
using System.IO.Compression;
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
        public void ThenTheResultShouldBe(int p0)
        {

        }

        [Then(@"the content should be valid JSON")]
        public void ThenTheResponseShouldBeValidJson()
        {
            var responseContentTask = _context.ResponseMessage.Content.ReadAsStringAsync();
            Task.WaitAll(responseContentTask);
            JsonConvert.DeserializeObject(responseContentTask.Result);
        }

        [Then(@"the response should be '(.*)' compressed")]
        public void ThenTheResponseShouldBeGzipCompressed(string compressionMethod)
        {

            var responseContentTask = _context.ResponseMessage.Content.ReadAsByteArrayAsync();
            Task.WaitAll(responseContentTask);

            using (var ms = new MemoryStream(responseContentTask.Result))
            {
                switch (compressionMethod.Trim().ToLowerInvariant())
                {
                    case "gzip":
                        using (var gzipStream = new GZipStream(ms, CompressionMode.Decompress))
                        {
                            byte[] buffer = new byte[1024];
                            while ((gzipStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                            }
                        }
                        break;
                    case "deflate":
                        using (var deflateStream = new DeflateStream(ms, CompressionMode.Decompress))
                        {
                            byte[] buffer = new byte[1024];
                            while ((deflateStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                            }
                        }
                        break;
                    default:
                        throw new ArgumentException(string.Format("{0} is not a valid compression method", compressionMethod));
                }

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