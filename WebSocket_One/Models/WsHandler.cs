using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using System.Net.WebSockets;

namespace WebSocket_One.Models
{
    public class WsHandler : IHttpHandler
    {
        private static bool mqCreated = false;
        private static Dictionary<string, WebSocket> con_Pool = new Dictionary<string, WebSocket>();//连接池
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(ProcessChat);
            }
        }

        public bool IsReusable { get { return false; } }
    }
}