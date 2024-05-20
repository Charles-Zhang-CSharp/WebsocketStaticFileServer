
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketStaticFileServer
{
    public class StaticServer : WebSocketBehavior
    {
        #region Construction
        public string RootFolder { get; set; }
        #endregion

        #region Methods
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.IsText)
            {
                string data = e.Data;
                Send($"Invalid data type for {data}, expected only binary formats.");
            }

            if (e.IsBinary)
            {
                byte[] data = e.RawData;
                // TODO: Implement Echo
            }
        }
        #endregion
    }
}