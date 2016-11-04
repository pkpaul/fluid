using ServiceStack.Text;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluid.Domain.Repository
{
    public class RedisContext : IRedisContext
    {
        private IConnectionMultiplexer Redis;
        private IDatabase db;
        public RedisContext(IConnectionMultiplexer redis)
        {
            Redis = redis;
            db = Redis.GetDatabase(1);
        }


        public T Get<T>(string itemType, Guid id)
        {
            var getItem = db.StringGet(string.Format("{0}:{1}", itemType, id));
            return JsonSerializer.DeserializeFromString<T>(getItem);
        }

        public void Add<T>(string itemType, T item) where T : DatabaseItem
        {
            var deploy = JsonSerializer.SerializeToString(item);
            db.StringSet(string.Format("{0}:{1}", itemType, item.Id), deploy);
            db.ListRightPush(string.Format("{0}list", itemType), deploy);
        }

        public List<T> List<T>(string itemType, int skip = 0, int take = 10)
        {
            var final = new List<T>();
            var results = db.ListRange(string.Format("{0}list", itemType), 0, skip + take -1);
            foreach (var item in results)
            {
                final.Add(JsonSerializer.DeserializeFromString<T>(item));
            }

            return final;
        }
    }

    public interface DatabaseItem
    {
        Guid Id { get; set; }
    }
    public interface IRedisContext
    {
        T Get<T>(string itemType, Guid id);
        void Add<T>(string itemType, T item) where T : DatabaseItem;
        List<T> List<T>(string itemType, int skip = 0, int take = 10);
    }

    
}
