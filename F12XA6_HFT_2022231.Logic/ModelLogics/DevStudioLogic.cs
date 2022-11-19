using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using static F12XA6_HFT_2022231.Logic.ModelLogics.DeveloperLogic;

namespace F12XA6_HFT_2022231.Logic
{
    public class DevStudioLogic
    {
        private IRepository<DevStudio> repo;

        public DevStudioLogic(IRepository<DevStudio> reop)
        {
            this.repo = reop;
        }
        public IEnumerable<ICollection<Game>> ValamiGamesByStudioName(string studioname) //Returns a list that contains the name of workers for a studio
        {
            var res =
                repo.ReadAll().Where(t => t.StudioName == studioname).Select(t => t.Games);
            return res;
        }

        public class StudiInfo
        {
            public IEnumerable<string> GameTytles { get; set; }
            public string StudioName { get; set; }
        }
    }
}
