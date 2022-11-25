using System.Collections.Generic;
using F12XA6_HFT_2022231.Logic;
using F12XA6_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using static F12XA6_HFT_2022231.Logic.ModelLogics.GameLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameLogic logic;

        public GameController(IGameLogic logic)
        {
            this.logic = logic;
        }

    

     

   
        // GET: api/<GameController>
        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<GameController>
        [HttpPost]
        public void Create([FromBody] Game value)
        {
            this.logic.Create(value);
        }

        // PUT api/<GameController>/5
        [HttpPut]
        public void Update([FromBody] Game value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

    }
}
