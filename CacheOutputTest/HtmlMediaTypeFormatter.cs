using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CacheOutputTest
{
    public class HtmlMediaTypeFormatter : MediaTypeFormatter
    {
        public HtmlMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream,
            System.Net.Http.HttpContent content, TransportContext transportContext)
        {
            var taskSource = new TaskCompletionSource<object>();
            var doc = new HtmlDocument();
            var htmlElement = doc.CreateElement("html");
            doc.DocumentNode.AppendChild(htmlElement);

            htmlElement.InnerHtml = "html:" + (string) value;
            doc.Save(writeStream);
            taskSource.SetResult(null);
            return taskSource.Task;
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return (
                type == typeof(string)
                    );
        }
    }
}