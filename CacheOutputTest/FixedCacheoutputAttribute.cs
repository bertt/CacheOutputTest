using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI.OutputCache;

namespace CacheOutputTest
{
    public class FixedCacheOutput : CacheOutputAttribute
    {
        private static MediaTypeHeaderValue _defaultMediaType = new MediaTypeHeaderValue("application/json");

        protected override MediaTypeHeaderValue GetExpectedMediaType(HttpConfiguration config, HttpActionContext actionContext)
        {
            MediaTypeHeaderValue responseMediaType = null;

            var negotiator = config.Services.GetService(typeof(IContentNegotiator)) as IContentNegotiator;
            var returnType = actionContext.ActionDescriptor.ReturnType;

            if (negotiator != null && returnType != typeof(HttpResponseMessage))
            {
                var negotiatedResult = negotiator.Negotiate(returnType, actionContext.Request, config.Formatters);
                responseMediaType = negotiatedResult.MediaType;
            }
            else
            {
                if (actionContext.Request.Headers.Accept != null)
                {
                    responseMediaType = actionContext.Request.Headers.Accept.FirstOrDefault();
                    if (responseMediaType == null ||
                        !config.Formatters.Any(x => x.SupportedMediaTypes.Contains(responseMediaType)))
                    {
                        return _defaultMediaType;
                    }
                }
            }

            return responseMediaType;
        }
    }
}