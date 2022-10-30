using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;

namespace F12XA6_HFT_2022231.Repository
{
    internal class DirectorRepository : Repository<Developer>, IRepository<Developer>
    {
        private readonly GameDbContext context;
        public DirectorRepository(GameDbContext context) : base(context)
        {
            this.context = context;
        }

        public override bool Update(Developer item)
        {
            var sourceItem = Read(item.Id);
            if (sourceItem == null)
            {
                return false;
            }


            sourceItem.CopyFrom(item);
            context.SaveChanges();
            return true;
        }
    }
}
