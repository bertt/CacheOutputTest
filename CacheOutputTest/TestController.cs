using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.OutputCache;

namespace CacheOutputTest
{
    public class TestController:ApiController
    {
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        public HttpResponseMessage GetTest()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                "test");
        }
    }
}