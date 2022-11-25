using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Logic.ModelLogics;
using F12XA6_HFT_2022231.Models;

namespace F12XA6_HFT_2022231.Logic
{
    public interface IGameLogic
    {
        public void Create(Game item);
        public Game Read(int id);
        public IEnumerable<Game> ReadAll();
        public void Update(Game item);
        public void Delete(int Id);

        public IEnumerable<Game.GameInfo> GameCountByStudio();
        public IEnumerable<Game.GameInfo> AvgRatingByStudio();

    }
}
