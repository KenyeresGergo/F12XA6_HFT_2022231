using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F12XA6_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;

namespace F12XA6_HFT_2022231.Repository
{
    public class GameDbContext : DbContext
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
               // string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Game.mdf;Integrated Security=True;MultipleActiveResultSets=True";

               bulider.UseLazyLoadingProxies().UseInMemoryDatabase("GameDb");
               //.UseSqlServer(conn);
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
                    new Game(1,"Cyberpunk2077", 60, 1,2),
                    new Game(2,"Grand Theft Auto V", 50, 2,7),
                    new Game(3,"Grand Theft Auto IV", 30, 2,6),
                    new Game(4,"The Witcher 3: Wild hunt", 55, 1,4),
                    new Game(5,"DOOM Ethernal", 40, 3,3),
                    new Game(6,"Far Cry 6", 70, 4,5),
                    new Game(7,"Far Cry 3", 20, 4,10),
                    new Game(8,"Just Cause 4", 35, 5,8),
                    new Game(9,"Valorant", 0, 6,4),
                    new Game(10,"Call of Duty 4: Modern Warfare", 10, 7, 9),
                    new Game(11,"Sekiro: Shadows Die Twice", 70,8,7),
                    new Game(12,"Resident Evil 2", 55,9,8),
                    new Game(13,"Left 4 Dead 2", 5,10,9),
                    new Game(14,"Star Wars Battlefront II", 42,11,6),
                    new Game(15,"Among Us", 0,12,2),
                    new Game(16,"BioShock Infinite", 15,13,10),
                    new Game(17,"Borderlands 2", 30,14,10),
                    new Game(18,"Shadow of the Tomb Raider", 10,5,8),
                    new Game(19,"Watch Dogs 2", 50,4,3),
                    new Game(20,"World War Z", 42,16,7),
                    new Game(21,"Devil May Cry 5", 25,9,9),
                    new Game(22,"Metal Gear Solid V: The Phantom Pain", 38,17,9),
                    new Game(23,"Silent Hill", 26,17,4),
                    new Game(24,"Red Dead Redemption 2", 65,2,9),
                    new Game(25,"Assassin's Creed Odyssey", 60,4,6),
                    new Game(25,"For Honor", 50,4,5),
                    new Game(25,"Tom Clancy's The Division", 70,4,8),
                    new Game(25,"TCrash Team Racing Nitro-Fueled", 40,8,6),
                    new Game(25,"NBA 2K22", 70,13,8),
                    
                    
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
                    new DevStudio(8,"Activision"),
                    new DevStudio(9,"Capcom"),
                    new DevStudio(10,"Valve Co."),
                    new DevStudio(11,"Gordy Haab"),
                    new DevStudio(12,"InnerSloth LLC"),
                    new DevStudio(13,"2K Games"),
                    new DevStudio(14,"Gearbox Sofware"),
                    new DevStudio(15,"Square Enix"),
                    new DevStudio(16,"Saber Interactive"),
                    new DevStudio(17,"Kojima Productions"),

                }
            );
            modelBuilder.Entity<Developer>().HasData(new Developer[]
                {
                    new Developer(1,"John",4,64000),
                    new Developer(2,"Cater",1,128000),
                    new Developer(3,"Monica",4,32000),
                    new Developer(4,"Mike",1,78000),
                    new Developer(5,"Liam",3,69000),
                    new Developer(6,"Noah",2,84000),
                    new Developer(7,"Emma",6,92000),
                    new Developer(8,"Olivia",7,87000),
                    new Developer(9,"Henry",8,66000),
                    new Developer(10,"James",5,37000),

                }
            );



        }



    }
}
