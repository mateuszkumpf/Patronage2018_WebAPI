using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patronage2018.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(e => e.RoomId).HasColumnName("RoomID");

            builder.HasIndex(e => e.RoomName).IsUnique();

            builder.Property(e => e.RoomName)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.HasMany(c => c.Calendars)
                   .WithOne(e => e.Room)
                   .HasForeignKey(c => c.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
