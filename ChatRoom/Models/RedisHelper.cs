using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class RedisHelper
    {
        public static RedisClient GetClient()
        {
            RedisClient redis = new RedisClient("123.207.67.80", 6379);
            return redis;
        }
    }
}