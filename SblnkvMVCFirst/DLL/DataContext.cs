using Microsoft.EntityFrameworkCore;
using SblnkvMVCFirst.Models;

namespace SblnkvMVCFirst.DLL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=surfing;Username=postgres;Password=sa");
        }
    }

}
