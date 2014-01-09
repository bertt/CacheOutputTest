using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CacheOutputTest
{
    public class Test3Controller:ApiController
    {
        [FixedCacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        public HttpResponseMessage GetTest()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                "test");
        }

    }
}