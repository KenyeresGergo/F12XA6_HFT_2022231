using F12XA6_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using F12XA6_HFT_2022231.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DevStudioNonCRUDController : ControllerBase
    {
        private IDevStudioLogic logic;

        public DevStudioNonCRUDController(IDevStudioLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<ICollection<Game>> GamesOfASelectedStudio(string studioname)
        {
            return this.logic.GamesOfASelectedStudio(studioname);
        }
    }
}
