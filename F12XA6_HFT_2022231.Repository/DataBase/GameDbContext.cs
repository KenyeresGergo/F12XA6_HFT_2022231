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



        }



    }
}
