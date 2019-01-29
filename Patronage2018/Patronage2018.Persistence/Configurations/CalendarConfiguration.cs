using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patronage2018.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Persistence.Configurations
{
    public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.Property(e => e.CalendarId).HasColumnName("CalendarID");

            builder.HasOne(e => e.Room)
                   .WithMany(c => c.Calendars)
                   .HasForeignKey(e => e.RoomId);
        }
    }
}
