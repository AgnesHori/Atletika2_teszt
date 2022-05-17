using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletika2.Models
{

    public class AppDbContext: DbContext
    {
        public DbSet<Helyszin> Helyszinek { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }
        public DbSet<Eredmenyek> Eredmenyek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Atletika2DB;Trusted_Connection=True");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eredmenyek>().HasOne(x => x.Helyszin);
            modelBuilder.Entity<Eredmenyek>().HasOne(x => x.Versenyzo);

            modelBuilder.Entity<Eredmenyek>().HasKey(model=>new
            {
                model.VersId,
                model.HelyId

            });
        }
    }
}
