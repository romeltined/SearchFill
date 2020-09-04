using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SearchFill.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchFill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chats1Controller : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public Chats1Controller(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // GET: api/<Chats1Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Chats1Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //just adding some comments
            return "value";
        }

        // POST api/<Chats1Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<Chats1Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Chats1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
