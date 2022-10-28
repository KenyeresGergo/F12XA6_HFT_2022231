using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F12XA6_HFT_2022231.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        public T Read(int id);
        IEnumerable<T> ReadAll();
        bool Update(T item);
        void Delete(int id);

    }
}
