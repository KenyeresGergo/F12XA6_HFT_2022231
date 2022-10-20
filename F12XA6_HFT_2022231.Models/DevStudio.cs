using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F12XA6_HFT_2022231.Models
{
    [Table("Developer Studios")]
    internal class DevStudio :IDbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(240)]
        public string Name { get; set; }

        
        public ICollection<int> GamesIds { get; set; }

        
        public ICollection<int> EmployeesIds { get; set; }
    }
}
