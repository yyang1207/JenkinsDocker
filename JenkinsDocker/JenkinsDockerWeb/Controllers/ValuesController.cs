using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JenkinsDockerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private ILogger _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //string ip = "192.168.0.2";
            //string port = Request.HttpContext.Connection.LocalPort.ToString();

            ////_logger.LogInformation("这是一条测试日志信息");
            ////_logger.LogWarning("这是一条测试日志信息Warn");
            ////_logger.LogError("这是一条测试日志信息Error");

            //return new string[] { ip, port };

            List<string> lst = new List<string>();
            lst.Add($"X-Real-IP  --->   {Request.Headers["X-Real-IP"]}      ");
            lst.Add($"RemoteIpAddress  --->   {Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()}:{Request.HttpContext.Connection.RemotePort}");
            lst.Add($"X-Forwarded-For   --->    {Request.Headers["X-Forwarded-For"]}");

            return lst;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
