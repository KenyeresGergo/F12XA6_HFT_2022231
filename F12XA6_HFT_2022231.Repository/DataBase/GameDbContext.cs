using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;

namespace F12XA6_HFT_2022231.Repository
{
    internal class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<DevStudio> Studios { get; set; }


        public GameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder bulider)
        {
            if (!bulider.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Games.mdf;Integrated Security=True";

                bulider.UseLazyLoadingProxies().UseSqlServer(conn);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)          //TODO   dev lista
        {
            modelBuilder.Entity<Game>(game => game
                .HasOne(game => game.PublisherStudio)
                .WithMany(studio => studio.Games)
                .HasForeignKey(game => game.PublisherStudioId)
            );

            modelBuilder.Entity<Developer>(dev => dev
                .HasOne(dev => dev.Company)
                .WithMany(company => company.Employees)
                .HasForeignKey(dev => dev.CompanyId)
            );

            modelBuilder.Entity<DevStudio>(Studio => Studio
                .HasMany(studio => studio.Games)
                .WithOne( game => game.PublisherStudio)
            );

            modelBuilder.Entity<Game>().HasData(new Game[]
                {
                    new Game(1,"Cyberpunk2077", 60, 1),
                    new Game(2,"Grand Theft Auto V", 50, 2),
                    new Game(3,"Grand Theft Auto IV", 30, 2),
                    new Game(4,"The Witcher 3: Wild hunt", 55, 1),
                    new Game(5,"DOOM Ethernal", 40, 3),
                    new Game(6,"Far Cry 6", 70, 4),
                    new Game(7,"Far Cry 3", 20, 4),
                    new Game(8,"Just Cause 4", 35, 5),
                    new Game(9,"Valorant", 0, 6),
                    new Game(10,"Call of Duty 4: Modern Warfare", 10, 7),
                    new Game(11,"Sekiro: Shadows Die Twice", 70,8)
                    
                }
            );
            modelBuilder.Entity<DevStudio>().HasData(new DevStudio[]
                {
                    new DevStudio(1,"CD Pojekt RED"),
                    new DevStudio(2,"Rockstar Games"),
                    new DevStudio(3,"Panic Button Games"),
                    new DevStudio(4,"Ubisoft"),
                    new DevStudio(5,"Avalanche Studios Group"),
                    new DevStudio(6,"Riot Games"),
                    new DevStudio(7,"Infiniti Ward"),
                    new DevStudio(8,"Activision")

                }
            );
            modelBuilder.Entity<Developer>().HasData(new Developer[]
                {
                    new Developer(1,"John",4,64000),
                    new Developer(2,"Cater",1,64000),
                    new Developer(3,"Monica",4,64000),
                    new Developer(4,"Mike",1,64000),
                    new Developer(5,"Liam",3,64000),
                    new Developer(6,"Noah",2,64000),
                    new Developer(7,"Emma",6,64000),
                    new Developer(8,"Olivia",7,64000),
                    new Developer(9,"Henry",8,64000),
                    new Developer(10,"James",5,64000),

                }
            );



        }



    }
}
