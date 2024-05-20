using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketStaticFileServer.UnitTests
{
    public class ListCommandTest : IDisposable
    {
        private WebSocketServer WebsocketServer;
        #region Start and End Resources
        public ListCommandTest()
        {
            // Start server
            WebsocketServer = new WebSocketServer("ws://localhost:9991");

            WebsocketServer.AddWebSocketService<StaticServer>("/Endpoint");
            WebsocketServer.Start();
        }
        public void Dispose()
        {
            // WebsocketServer.Stop(); // This cause issues: get stuck and blocks the program.
        }
        #endregion

        [Fact]
        public void ListGet()
        {
            using var ws = new WebSocket("ws://localhost:9991/Endpoint");
            ws.OnMessage += (sender, e) => Assert.Equal("Echo", System.Text.Encoding.UTF8.GetString(e.RawData));

            ws.Connect();
            ws.Send(System.Text.Encoding.UTF8.GetBytes("Echo"));
            Thread.Sleep(5000);
        }
    }
}