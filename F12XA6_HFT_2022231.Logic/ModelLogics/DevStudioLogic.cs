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
        #region nonCRUD methods
        public IEnumerable<ICollection<Game>> GamesOfASelectedStudio(string studioname) //Returns a list that contains the name of workers for a studio order by the number of games
        {
            var res =
                repo.ReadAll().Where(t => t.StudioName == studioname).Select(t => t.Games).OrderBy(t=>t.Count);
            return res;
        }
        public void Create(DevStudio item)
        {
            this.repo.Create(item);
        }
        public DevStudio Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<DevStudio> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(DevStudio item)
        {
            this.repo.Update(item);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }


        #endregion
        public class StudiInfo
        {
            public IEnumerable<string> GameTytles { get; set; }
            public string StudioName { get; set; }
            public IEnumerable<string> DevStudionames { get; set; }

        }
    }
}
