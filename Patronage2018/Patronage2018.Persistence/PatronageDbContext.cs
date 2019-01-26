using Microsoft.EntityFrameworkCore;
using Patronage2018.Domain.Entities;

namespace Patronage2018.Persistence
{
    public class PatronageDbContext : DbContext
    {
        public PatronageDbContext(DbContextOptions<PatronageDbContext> options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Calendar> Calendars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatronageDbContext).Assembly);
        }
    }
}
