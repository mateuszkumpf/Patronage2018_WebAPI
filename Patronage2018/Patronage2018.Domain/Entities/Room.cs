using Patronage2018.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            Calendars = new HashSet<Calendar>();
        }

        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public ICollection<Calendar> Calendars { get; private set; }

        public override string ToString()
        {
            return $"RoomId: {RoomId}{Environment.NewLine}RoomName: {RoomName}";
        }
    }
}
