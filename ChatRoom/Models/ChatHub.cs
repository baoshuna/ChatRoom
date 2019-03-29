using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatRoom.Models
{
    //[HubName("MyDisplayName")]
    public class ChatHub:Hub
    {
        RedisClient redis = RedisHelper.GetClient();

        /// <summary>发送消息</summary>
        public void SendMsg(string name,string message)
        {
            Clients.All.sendMessage(name, message);
            //var context = HttpContext.Current;
            //var x = Context.QueryString["myQs"];
            //var x = Context.ConnectionId;
            //var p = new PrincipalUserIdProvider();
            //GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => p);


        }

        /// <summary>欢迎语</summary>
        public void JoinGroup(string name)
        {
            Clients.All.welcome(name);
            Clients.Caller.welcomeName(name);
        }
        /// <summary>加载页面/刷新页面重新加载的时候触发（$.connection.hub.start()）</summary>
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        /// <summary>在离开（关闭选项卡/刷新页面）的时候触发（$.connection.hub.stop()）</summary>
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        //public string GetUserId(IRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}