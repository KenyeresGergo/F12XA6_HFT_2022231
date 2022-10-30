using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;

namespace F12XA6_HFT_2022231.Repository
{
    internal class DevStudioRepository : Repository<DevStudio>, IRepository<DevStudio>
    {
        private readonly GameDbContext context;

        public DevStudioRepository(GameDbContext context) : base(context)
        {
            this.context = context;
        }

        public override bool Update(DevStudio item)
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
