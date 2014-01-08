using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CacheOutputTest
{
    public class Test2Controller:ApiController
    {
        public HttpResponseMessage GetTest()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                "test");
        }
    }
}