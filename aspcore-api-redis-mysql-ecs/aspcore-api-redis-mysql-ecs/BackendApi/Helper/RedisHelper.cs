using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Helper
{
    public class RedisHelper
    {
        public void AddRandomValuesToHash()
        {
            var manager = new RedisManagerPool(Environment.GetEnvironmentVariable("REDIS_SERVER"));
            using (var client = manager.GetClient())
            {
                for (int loopIndex = 0; loopIndex < 5; loopIndex++)
                {
                    client.SetEntryInHash("hashKey", Guid.NewGuid().ToString(), loopIndex.ToString());
                }

            }
        }

        public Dictionary<string, string> GetValuesFromHash(string hashKey)
        {
            var manager = new RedisManagerPool(Environment.GetEnvironmentVariable("REDIS_SERVER"));
            using (var client = manager.GetClient())
            {

                return client.GetAllEntriesFromHash(hashKey);

            }
        }

    }
}
