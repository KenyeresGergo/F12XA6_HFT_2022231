using F12XA6_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static F12XA6_HFT_2022231.Logic.ModelLogics.DeveloperLogic;

namespace F12XA6_HFT_2022231.Logic.Interfaces
{
    public interface IDeveloperLogic
    {
        public void Create(DevStudio item);
        public DevStudio Read(int id);
        public IEnumerable<DevStudio> ReadAll();
        public void Update(DevStudio item);
        public void Delete(int Id);

        public IEnumerable<DeveloperInfo> EmployeeNamesByCompany();
    }
}
