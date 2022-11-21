using System.Collections.Generic;
using F12XA6_HFT_2022231.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IDeveloperLogic logic;

        public DeveloperController(IDeveloperLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<DeveloperController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeveloperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
