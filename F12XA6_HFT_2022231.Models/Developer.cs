using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

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
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual DevStudio Company { get; set; }

        public int Salary { get; set; }  //USD / year

        public Developer(int id, string devName, int companyId, int salary)
        {
            Id = id;
            DevName = devName;
            CompanyId = companyId;
            Salary = salary;
        }

        public Developer()
        {
            
        }

        public void CopyFrom(Developer other)  //TODO DevStudio-t copyzni
        {
            this.Id = other.Id;
            this.DevName = other.DevName;
            this.CompanyId = other.CompanyId;
            this.Salary = other.Salary;
            this.Company = other.Company;
        }
    }
}
