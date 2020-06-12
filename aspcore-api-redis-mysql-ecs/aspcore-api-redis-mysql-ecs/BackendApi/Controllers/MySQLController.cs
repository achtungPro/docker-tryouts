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
    public class MySQLController : ControllerBase
    {
        // POST api/redis
        [HttpPost]
        public void Post()
        {
            MySQLHelper mySQLHelper = new MySQLHelper();
            mySQLHelper.AddRandomValues(Environment.GetEnvironmentVariable("MYSQL_SERVER"), Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD"));
        }

        // GET api/redis
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                MySQLHelper mySQLHelper = new MySQLHelper();
                return Ok(mySQLHelper.GetAllValues(Environment.GetEnvironmentVariable("MYSQL_SERVER"), Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD")));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + "|" + ex.StackTrace);
            }
        }
    }
}