using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Messaging;

namespace WebSocket_One.Models
{
    public class Ws_Service
    {
        public static void Create()
        {
            MessageQueue mq = null;
            string path = @".\private$\mqDemo4";
            if (MessageQueue.Exists(path))
            {
                mq = new MessageQueue(path);
            }
            else
            {
                mq = MessageQueue.Create(path);
            }
            mq.SetPermissions("Anonymous LogOn", MessageQueueAccessRights.FullControl);
            mq.SetPermissions("Everyone", MessageQueueAccessRights.FullControl);
            mq.SetPermissions("Administrator", MessageQueueAccessRights.FullControl);
            System.Diagnostics.Debug.WriteLine("mqDemo4建立成功");
        }
    }
}