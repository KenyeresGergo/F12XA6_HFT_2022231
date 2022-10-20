using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F12XA6_HFT_2022231.Models
{
    [Table("Games")]
    internal class Game : IDbEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }

        public int Price { get; set; }

        public string DevStudio { get; set; }


    }
}
