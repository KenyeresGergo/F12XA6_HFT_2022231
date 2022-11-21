using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace F12XA6_HFT_2022231.Logic.ModelLogics
{
    public class GameLogic : IGameLogic
    {
        private IRepository<Game> repository;

        public GameLogic(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        public void Create(Game item)
        {
            if (item == null || item.Developers == null || item.GameTitle == null || item.PublisherStudio == null)
            {
                throw new ArgumentNullException();
            }
            else if (item.GameTitle.Length == 0)
            {
                throw new Exception("GameTitle can't be an empty string");
            }
            this.repository.Create(item);
        }
        public Game Read(int id)
        {
            return this.repository.Read(id);
        }

        public IEnumerable<Game> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Game item)
        {
            if (item == null || item.Developers == null || item.GameTitle == null || item.PublisherStudio == null)
            {
                throw new ArgumentNullException();
            }
            else if (item.GameTitle.Length == 0)
            {
                throw new Exception("GameTitle can't be an empty string");
            }
            this.repository.Update(item);
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
       
        #region non CRUD methods

        public IEnumerable<GameInfo> GameCountByStudio() //Returns the number of games produced by a studio
        {
            var res = from x in repository.ReadAll()
                group x by x.PublisherStudio
                into g
                select new GameInfo()
                {
                    PublisherStudioName = g.Key.StudioName,
                    GameCount = g.Key.Games.Count
                };
            return res;
        }

        public IEnumerable<GameInfo> AvgRatingByStudio() //Returns the average rating of games by a studio
        {
            var res = from x in repository.ReadAll()
                group x by x.PublisherStudio
                into g orderby g.Key.Id
                select new GameInfo
                {
                    AvgRating = g.Key.Games.Select(t => t.Rating).Average(),
                    PublisherStudioName = g.Key.StudioName
                };
            return res;
        }

        #endregion


        public class GameInfo
        {
            public string PublisherStudioName { get; set; }
            public int GameCount { get; set; }
            public double AvgRating { get; set; }
        }
    }

   
}
