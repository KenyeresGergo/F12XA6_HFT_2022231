﻿using System;
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

        [MaxLength(240)]
        public string GameTitle { get; set; }

        public int Price { get; set; }
        [Range(0,10)]
        public int Rating { get; set; }

        [Required]
        public int PublisherStudioId { get; set; }
        [NotMapped]
        public virtual DevStudio PublisherStudio { get; set; }

        [Required]
        public virtual ICollection<Developer> Developers { get; set; }

        public Game(int id, string gameTitle, int price, int publisherStudioId, int rating)
        {
            Id = id;
            GameTitle = gameTitle;
            Price = price;
            PublisherStudioId = publisherStudioId;
            Rating = rating;
            //PublisherStudio = 
            //Developers = PublisherStudio.Employees;
        }

        public Game()
        {
            
        }

        public void CopyFrom(Game old)
        {
            this.Id = old.Id;
            this.GameTitle = old.GameTitle;
            this.Price = old.Price;
            this.PublisherStudioId = old.PublisherStudioId;
            this.Developers = old.Developers;   
        }
    }
}
