using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceStack.Redis;

namespace aspcore_website_redis.Pages
{
    public class IndexModel : PageModel
    {
        public int Counter { get; set; } = 0;

        public void OnGet()
        {
            var manager = new RedisManagerPool("redis-server-docker");
            using (var client = manager.GetClient())
            {
                try
                {
                    Counter = client.Get<int>("CounterKey");
                }
                catch(Exception e)
                {
                    client.Set("CounterKey", Counter);
                }
                Counter = Counter + 1;
                client.Set("CounterKey", Counter);
               
            }
        }
    }
}
