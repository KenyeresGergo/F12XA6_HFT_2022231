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
    public class Game : IDbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength (240)]
        public string GameTitle  { get; set; }

        public int Price { get; set; }

        [Required]
        public int PublisherStudioId { get; set; }

        [Required]
        public ICollection<int> DeveloperIds { get; set; }


    }
}
