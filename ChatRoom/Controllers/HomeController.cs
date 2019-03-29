using ChatRoom.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Sockets;

namespace ChatRoom.Controllers
{
    public class HomeController : Controller
    {
        private IRedisClient client = RedisHelper.GetClient();
        /// <summary>聊天室主界面</summary>
        public ActionResult Chat()
        {
            return View();
        }

        /// <summary>更新聊天记录</summary>
        [HttpPost]
        public void UpdateHistoryMessage(string name, string message)
        {
            if (!string.IsNullOrWhiteSpace(message) && !string.IsNullOrWhiteSpace(name))
            {
                string date = DateTime.Now.ToString();
                HistoryMessage history = new HistoryMessage()
                {
                    Name = name,
                    Message = message,
                    MsgTime = date
                };
                string result = JsonConvert.SerializeObject(history, Formatting.Indented);
                client.AddItemToList("HistoryMessage", result);
            }
        }

        /// <summary>获取聊天记录</summary>
        public JsonResult GetHistory()
        {
            List<HistoryMessage> messages = new List<HistoryMessage>();
            var msgList = client.GetAllItemsFromList("HistoryMessage");
            foreach (var item in msgList)
            {
                messages.Add(JsonConvert.DeserializeObject<HistoryMessage>(item));
            }
            return Json(messages,JsonRequestBehavior.AllowGet);
        }
    }
    public class HistoryMessage
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string MsgTime { get; set; }
    }
}