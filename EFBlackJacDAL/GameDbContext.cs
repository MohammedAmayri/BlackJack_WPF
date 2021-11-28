using GameCardLib.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFBlackJacDAL
{
    public class GameDbContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BlackJackDataBase", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }

    }
}
