using EFBlackJacEL.Model;
using GameCardLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
namespace EFBlackJacDAL
{
    public class GameDbContext: DbContext
    {   
       
        public DbSet<Player> Players { get; set; }
        public DbSet<Dealer> Dealers { get; set; }

        public DbSet<PlayingHabit> playingHabits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BlackJackDataBaseWPF", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
       

    }
}
