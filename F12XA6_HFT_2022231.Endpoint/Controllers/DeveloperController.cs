using System.Collections.Generic;
using F12XA6_HFT_2022231.Logic.Interfaces;
using F12XA6_HFT_2022231.Logic.ModelLogics;
using F12XA6_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
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
        public IEnumerable<Developer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public Developer Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public void Create([FromBody] Developer value)
        {
            this.logic.Create(value);
        }

        // PUT api/<DeveloperController>/5
        [HttpPut]
        public void Update([FromBody] Developer value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
