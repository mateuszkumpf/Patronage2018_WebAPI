using Patronage2018.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Domain.Entity
{
    public class Room
    {
        public Room()
        {
            Calenders = new HashSet<Calender>();
        }

        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public ICollection<Calender> Calenders { get; private set; }
    }
}
