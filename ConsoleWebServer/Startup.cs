using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ConsoleWebServer.Server;
using ConsoleWebServer.Server.Http;
using ConsoleWebServer.Server.Results;

namespace ConsoleWebServer
{
    class Startup
    {
        public static async Task Main()
            => await new HttpServer(8888,
                    routes => routes
                .MapGet("/", new TextResponse("Hello from Me!"))
                .MapGet("/Cats", new TextResponse("<h1>Hello from the cats!</h1>","text/html"))
                .MapGet("/Dogs", new TextResponse("<h1>Hello from the dogs!</h1>", "text/html")))
                .Start();
        // await server;

    }
}
