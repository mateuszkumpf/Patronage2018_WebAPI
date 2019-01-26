using System;

namespace Patronage2018.Domain.Entities
{
    public class Calendar
    {
        public int CalendarId { get; set; }

        public int RoomId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Room Room { get; set; }
    }
}
