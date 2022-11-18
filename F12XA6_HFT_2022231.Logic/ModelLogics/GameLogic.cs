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

        public IEnumerable<Game> GamesByPublisherStudio()
        {
            var res = from x in repository.ReadAll()
                group x by x.PublisherStudio
                into g
                select new Game()
                {
                    PublisherStudio = g.Key,
                    GameTitle = g.Select(t=>t.GameTitle).ToString()//lehet szar
                };
            return res;
        }
    }
}
