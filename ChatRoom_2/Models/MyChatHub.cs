using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatRoom_2.Models
{
    public class MyChatHub : Hub
    {
        public void SendMessage(string name,string message)
        {
            //var x = Context.ConnectionId;
            Clients.All.SendMsg(name,message);
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}