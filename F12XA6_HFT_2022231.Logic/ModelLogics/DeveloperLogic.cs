using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;

namespace F12XA6_HFT_2022231.Logic.ModelLogics
{
    public class DeveloperLogic
    {
        private IRepository<Developer> repo;

        public DeveloperLogic(IRepository<Developer> repo)
        {
            this.repo = repo;
        }


        


        public class DeveloperInfo
        {
            public string CompanyName { get; set; }


        }
    }
}
