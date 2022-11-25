using F12XA6_HFT_2022231.Logic;
using Microsoft.AspNetCore.Mvc;
using static F12XA6_HFT_2022231.Logic.ModelLogics.GameLogic;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GameNonCRUDController : ControllerBase
    {
        private IGameLogic logic;

        public GameNonCRUDController(IGameLogic logic)
        {
            this.logic = logic;
        }



        [HttpGet]
        public IEnumerable<GameInfo> GameCountByStudio()
        {
            return this.logic.GameCountByStudio();
        }
        [HttpGet]
        public IEnumerable<GameInfo> AvgRatingByStudio()
        {
            return this.logic.AvgRatingByStudio();
        }

       
    }
}
