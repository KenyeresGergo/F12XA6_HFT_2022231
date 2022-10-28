using F12XA6_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;

namespace F12XA6_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDbEntity
    {
        private readonly GameDbContext context;

        public Repository(GameDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> ReadAll()
        {
            var returnValues = context.Set<T>();

            return returnValues;
        }

        public T Read(int i)
        {
            return ReadAll().FirstOrDefault(_ => _.Id == i);
        }

        public void Create(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int i)
        {
            var item = Read(i);
            context.Remove(item);
            context.SaveChanges();
        }

        public abstract bool Update(T item);

    }
}
