using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Calendars.Commands.CreateCalendar
{
    public class CreateCalendarCommand : IRequest<int>
    {
        public int RoomId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
