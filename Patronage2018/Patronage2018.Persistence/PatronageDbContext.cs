using Microsoft.EntityFrameworkCore;
using Patronage2018.Domain.Entities;
using Patronage2018.Domain.Entity;
using System;

namespace Patronage2018.Persistence
{
    public class PatronageDbContext : DbContext
    {
        public PatronageDbContext(DbContextOptions<PatronageDbContext> options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Calender> Calenders { get; set; }
    }
}
