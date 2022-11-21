using System.Collections.Generic;
using F12XA6_HFT_2022231.Logic;
using F12XA6_HFT_2022231.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevStudioController : ControllerBase
    {
        private IDevStudioLogic logic;

        public DevStudioController(IDevStudioLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<DevStudioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DevStudioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DevStudioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevStudioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DevStudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
