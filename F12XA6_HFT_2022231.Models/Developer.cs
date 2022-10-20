using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace F12XA6_HFT_2022231.Models
{
    [Table("Developers")]
    public class Developer : IDbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [MaxLength(240)]
        public string DevName { get; set; }

        public int CompanyId { get; set; }

        [Required]
        public virtual DevStudio Company { get; set; }

        public int Salary { get; set; }  //USD / year

        public Developer(int id, string devName, int companyId, int salary)
        {
            Id = id;
            DevName = devName;
            CompanyId = companyId;
            Salary = salary;
        }
    }
}
