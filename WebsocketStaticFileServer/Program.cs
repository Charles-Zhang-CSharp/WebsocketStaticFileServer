using WebSocketSharp.Server;

namespace WebsocketStaticFileServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rootFolder = args.Single();

            var wssv = new WebSocketServer("ws://localhost:9992");
            wssv.AddWebSocketService("/Endpoint", () => new StaticServer()
            {
                RootFolder = rootFolder
            });
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}
