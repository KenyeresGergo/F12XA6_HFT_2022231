using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace F12XA6_HFT_2022231.Logic
{
    public class DevStudioLogic
    {
        private IRepository<DevStudio> reop;

        public DevStudioLogic(IRepository<DevStudio> reop)
        {
            this.reop = reop;
        }

        //public IEnumerable<StudiInfo> GameTytlesByStudio()
        //{
        //    var res = from x in reop.ReadAll()
        //        group x by x.StudioName
        //        into g
        //        select new StudiInfo()
        //        {
        //            StudioName = g.Key,
        //            GameTytles = g.SelectMany(t => t.Games.Where(k => k.GameTitle))
        //        };
        //    return res;
        //}

        public class StudiInfo
        {
            public IEnumerable<string> GameTytles { get; set; }
            public string StudioName { get; set; }
        }
    }
}
