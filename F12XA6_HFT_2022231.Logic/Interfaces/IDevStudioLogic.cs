using F12XA6_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F12XA6_HFT_2022231.Logic
{
    public interface IDevStudioLogic
    {
        public void Create(Developer item);
        public Developer Read(int id);
        public IEnumerable<Developer> ReadAll();
        public void Update(Developer item);
        public void Delete(int Id);

        public IEnumerable<ICollection<Game>> GamesOfASelectedStudio(string studioname);

    }
}
