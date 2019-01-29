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

        public override bool Equals(object obj)
        {
            if (!(obj is Calendar other))
            {
                return false;
            }

            return From == other.From && To == other.To && RoomId == other.RoomId;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(RoomId, From, To).GetHashCode();
        }

        public override string ToString()
        {
            return $"CalendarID: {CalendarId}{Environment.NewLine}RoomID: {RoomId}{Environment.NewLine}From: {From}{Environment.NewLine}To: {To}";
        }
    }
}
