using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F12XA6_HFT_2022231.Models
{
    [Table("Developers")]
    internal class Developer : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DevStudio Company { get; set; }

        public int Salary { get; set; }


    }
}
