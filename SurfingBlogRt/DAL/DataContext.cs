using Microsoft.EntityFrameworkCore;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.DAL
{
    public class DataContext : DbContext
    {

        public DbSet<Vacancy> Announcements { get; set; }

        public DataContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=internshipsBlog;Username=postgres;Password=postgres");

            optionsBuilder.UseMySql("Server=MYSQL5030.site4now.net;Database=db_a84332_studdb;Uid=a84332_studdb;Pwd=a02se03sa",
                new MySqlServerVersion(new Version(8, 0, 11))
                );
        }
    }
}
