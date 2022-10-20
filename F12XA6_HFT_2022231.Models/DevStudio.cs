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
    public class DevStudio : IDbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(240)]
        public string StudioName { get; set; }


        public ICollection<Game> Games { get; set; }


        public ICollection<Developer> Employees { get; set; }


        public DevStudio(int id, string studioName)
        {
            Id = id;
            StudioName = studioName;
        }

        public DevStudio()
        {
                
        }
    }
}
