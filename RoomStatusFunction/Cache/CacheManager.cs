using System;
using System.Configuration;
using StackExchange.Redis;

namespace RoomStatusFunction.Cache
{
    public class CacheManager
    {        
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisConnectionString"]);
        });

        private static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        public static RedisValue GetValue(string key)
        {
            var db = Connection.GetDatabase();
            return db.StringGet(key);
        }
    }
}