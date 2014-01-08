using System;
using System.Web.Http;
using System.Web.Routing;

namespace CacheOutputTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );
            var htmlMediaTypeFormatter = new HtmlMediaTypeFormatter();
            GlobalConfiguration.Configuration.Formatters.Add(htmlMediaTypeFormatter);
        }

    }
}