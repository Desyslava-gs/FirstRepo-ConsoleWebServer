using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";
        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }
        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines.First().Split(" ");

            var method = ParseHttpMethod(startLine[0]);

            var url = startLine[1];
            var headers = ParseHttpHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join(NewLine,bodyLines);

            return new HttpRequest()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HttpMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch

            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Method '{method}' is not supported!")
            };
        }

        private static HttpHeaderCollection ParseHttpHeaders(IEnumerable<string> headerLines)
        {
            var headrCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine ==String.Empty)
                {
                    break;
                }
                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                var header = new HttpHeader(headerName, headerValue);
                headrCollection.Add(headerName,headerValue);
            }

            return headrCollection;
        }

        //private static string[] GetStartLine(string request)
        //{

        //}
    }
}
