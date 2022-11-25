using F12XA6_HFT_2022231.Logic.Interfaces;
using F12XA6_HFT_2022231.Logic.ModelLogics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using F12XA6_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F12XA6_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DeveloperNonCRUDController : ControllerBase
    {
        private IDeveloperLogic logic;

        public DeveloperNonCRUDController(IDeveloperLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Developer.DeveloperInfo> EmployeeNamesByCompany()
        {
            return this.logic.EmployeeNamesByCompany();
        } 
        [HttpGet]
        public IEnumerable<Developer.DeveloperInfo> GamesCountByWorkplace()
        {
            return this.logic.GamesCountByWorkplace();
        }
    }
}
