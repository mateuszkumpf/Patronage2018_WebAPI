using Patronage2018.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Domain.Entities
{
    public class Calender
    {
        public int RoomId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Room Room { get; set; }
    }
}
