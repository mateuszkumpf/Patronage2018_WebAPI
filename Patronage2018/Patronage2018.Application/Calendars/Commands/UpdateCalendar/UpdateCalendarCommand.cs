using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Calendars.Commands.UpdateCalendar
{
    public class UpdateCalendarCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
