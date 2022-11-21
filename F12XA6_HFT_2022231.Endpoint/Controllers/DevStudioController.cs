using System.Collections.Generic;
using F12XA6_HFT_2022231.Logic;
using F12XA6_HFT_2022231.Logic.Interfaces;
using F12XA6_HFT_2022231.Models;
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
        public IEnumerable<DevStudio> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<DevStudioController>/5
        [HttpGet("{id}")]
        public DevStudio Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<DevStudioController>
        [HttpPost]
        public void Create([FromBody] DevStudio value)
        {
            this.logic.Create(value);
        }

        // PUT api/<DevStudioController>/5
        [HttpPut]
        public void Update([FromBody] DevStudio value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<DevStudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
