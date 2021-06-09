using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWebServer.Server.Http;

namespace ConsoleWebServer.Server.Routing
{
   public interface IRoutingTabe
   {
       IRoutingTabe Map(string url,HttpMethod method, HttpResponse response);
       IRoutingTabe MapGet(string url, HttpResponse response);
       //void MapPost(string url, HttpResponse response);
   }
}
