using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Logic.Interfaces;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;

namespace F12XA6_HFT_2022231.Logic.ModelLogics
{
    public class DeveloperLogic : IDeveloperLogic
    {
        private IRepository<Developer> repo;

        public DeveloperLogic(IRepository<Developer> repo)
        {
            this.repo = repo;
        }

        public void Create(Developer item)
        {
            if (item.Company is null || item.Salary == 0)
            {
                throw new ArgumentNullException();
            }
            else if (item.DevName.Length == 0)
            {
                throw new Exception("The name of the developer can't be an empty string");
            }
            this.repo.Create(item);
        }
        public Developer Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<Developer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Developer item)
        {
            this.repo.Update(item);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        

        #region nonCRUD methods

        public IEnumerable<Developer.DeveloperInfo> EmployeeNamesByCompany()//Return the names of the workers by company
        {
            var res = from x in repo.ReadAll()
                group x by x.Company
                into g orderby g.Key.Id
                select new Developer.DeveloperInfo
                {
                    CompanyName = g.Key.StudioName,
                    Developernames = g.Key.Employees.Select(t => t.DevName).ToList()
                };
            return res;
        }

        public IEnumerable<Developer.DeveloperInfo> GamesCountByWorkplace()//developer cegenek hany jateka van
        {
            var res = from x in repo.ReadAll()
                group x by x.Company
                into g
                select new Developer.DeveloperInfo()
                {
                    CompanyName = g.Key.StudioName,
                    GameCount = g.Key.Games.Count
                };
            return res;
        } 

        #endregion
    }
}
