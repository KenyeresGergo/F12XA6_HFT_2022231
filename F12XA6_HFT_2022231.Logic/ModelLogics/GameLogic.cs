using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;

namespace F12XA6_HFT_2022231.Logic.ModelLogics
{
    public class GameLogic
    {
        private IRepository<Game> repository;

        public GameLogic(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        //public IEnumerable<DevStudio> GamesByPublisherStudio()
        //{
        //    var res = from x in repository.ReadAll()
        //        group x by x.PublisherStudio.StudioName
        //        into g
        //        select new Game()
        //        {
        //            PublisherStudio = g.Key.ToString(),
        //            GameTitle = g.Select(t=>t.GameTitle).ToString()//lehet szar
        //        };
        //    return res;
        //}

        public IEnumerable<GameInfo> GameCountByStudio() //Returns the number of games produced by a studio
        {
            var res = from x in repository.ReadAll()
                group x by x.PublisherStudio
                into g
                select new GameInfo()
                {
                    PublisherStudioNameName = g.Key.StudioName,
                    GameCount = g.Key.Games.Count
                };
            return res;
        }
      
        public class GameInfo
        {
            public string PublisherStudioNameName { get; set; }
            public string GameName { get; set; }
            public int GameCount { get; set; }
           
        }
    }

   
}
