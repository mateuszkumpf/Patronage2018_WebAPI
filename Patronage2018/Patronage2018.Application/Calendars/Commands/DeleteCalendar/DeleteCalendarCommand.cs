using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Calendars.Commands.DeleteCalendar
{
    public class DeleteCalendarCommand : IRequest
    {
        public int Id { get; set; }
    }
}
