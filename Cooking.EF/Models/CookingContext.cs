using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.EF.Models
{
    public class CookingContext : DbContext
    {
        private readonly string _connectionString;

        public CookingContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<ChallengeEF> Challenges { get; set; }
        public DbSet<ImageEF> Images { get; set; }
        public DbSet<RecipeEF> Recipes { get; set; }
        public DbSet<UserEF> Users { get; set; }
        public DbSet<LikeEF> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}