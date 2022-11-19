using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;

namespace F12XA6_HFT_2022231.Logic.ModelLogics
{
    public class DeveloperLogic
    {
        private IRepository<Developer> repo;

        public DeveloperLogic(IRepository<Developer> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<DevStudioLogic.StudiInfo> EmployeeNamesByCompany()//REturn the names of the workers by company
        {
            var res = from x in repo.ReadAll()
                group x by x.Company
                into g
                select new DevStudioLogic.StudiInfo
                {
                    StudioName = g.Key.StudioName,
                    Developernames = g.Key.Employees.Select(t => t.DevName)
                };
            return res;
        }



        public class DeveloperInfo
        {
            public string CompanyName { get; set; }


        }
    }
}
