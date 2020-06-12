using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        // POST api/redis
        [HttpPost]
        public void Post()
        {
            RedisHelper helper = new RedisHelper();
            helper.AddRandomValuesToHash();
        }

        // GET api/redis
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                RedisHelper helper = new RedisHelper();
                return Ok(helper.GetValuesFromHash("hashKey"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "|" + ex.StackTrace);
            }
        }

    }
}