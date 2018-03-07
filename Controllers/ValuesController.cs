using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IoTApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("LightOn")]
        public IEnumerable<string> LightOn()
        {
            var tcpClient = new TcpClient("192.168.0.80", 4000);
            var data = System.Text.Encoding.ASCII.GetBytes("1");
            var stream = tcpClient.GetStream();
            stream.Write(data, 0, data.Length);

            data = new Byte[256];

            // String to store the response ASCII representation.
            var responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            var bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            // Close everything.
            stream.Close();
            tcpClient.Close();

            return new string[] { responseData };
        }

        [HttpGet]
        [Route("LightOff")]
        public IEnumerable<string> LightOff()
        {
            var tcpClient = new TcpClient("192.168.0.80", 4000);
            var data = System.Text.Encoding.ASCII.GetBytes("0");
            var stream = tcpClient.GetStream();
            stream.Write(data, 0, data.Length);

            data = new Byte[256];

            // String to store the response ASCII representation.
            var responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            var bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            // Close everything.
            stream.Close();
            tcpClient.Close();

            return new string[] { responseData };
        }


    }
}
