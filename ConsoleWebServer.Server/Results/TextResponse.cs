using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWebServer.Server.Common;
using ConsoleWebServer.Server.Http;

namespace ConsoleWebServer.Server.Results
{
    public class TextResponse : HttpResponse
    {
    
        public TextResponse(string text, string contentType = null)
            : base(HttpStatusCode.Ok)
        {
            Guard.AgainstNull(text);

            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type:", contentType);
            this.Headers.Add("Content-Length:", contentLength);

            this.Content = text;
        }

        public TextResponse(string text)
            :this(text,"text/plain; charset=UTF-8")
        {

        }
    }
}
