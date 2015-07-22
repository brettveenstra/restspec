using System;
using System.Configuration;
using System.Net;
using System.Net.Cache;
using System.Net.Http;

namespace restspec
{
    public class HttpTestContext
    {
        public HttpTestContext()
        {
            BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
            RequestMessage = new HttpRequestMessage();
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient(new WebRequestHandler
            {
                CachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAgeAndMinFresh, TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(0))
            })
            {
                BaseAddress = BaseAddress
            };
        }

        /// <summary>
        /// Gets or sets the accept header.
        /// </summary>
        /// <value>
        /// The accept header.
        /// </value>
        public string AcceptHeader { get; set; }
  


        /// <summary>
        /// Gets the base URI.
        /// </summary>
        /// <value>
        /// The base URI.
        /// </value>
        public Uri BaseAddress { get; private set; }
        public HttpRequestMessage RequestMessage { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public string ResponseContent { get; set; }
        public DecompressionMethods DecompressionMethod { get; set; }
    }
}