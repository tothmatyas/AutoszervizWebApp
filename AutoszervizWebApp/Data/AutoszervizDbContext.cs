using AutoszervizWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoszervizWebApp.Data
{
    public class AutoszervizDbContext : DbContext
    {
        public AutoszervizDbContext(DbContextOptions<AutoszervizDbContext> options) : base(options)
        {
        }
        
        public DbSet<Models.Ugyfel> Ugyfelek { get; set; }
        public DbSet<Models.Javitas> Javitasok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Javitas>()
            .HasOne(j => j.Ugyfel)
            .WithMany(u => u.Javitasok)
            .HasForeignKey(j => j.UgyfelId)
            .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
