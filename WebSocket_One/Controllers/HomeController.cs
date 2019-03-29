using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.WebSockets;
using System.Web.WebSockets;

namespace WebSocket_One.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }

        /// <summary>处理WebSocket请求</summary>
        public JsonResult Handlder()
        {
            WebSocket socket = AspNetWebSocketContext.ConnectionCount;
            return Json("");
        }
    }
}