using MediatR;
using Patronage2018.Application.Calendars.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Calendars.Queries.GetRoomsCalendar
{
    public class GetRoomsCalendarQuery : IRequest<CalendarsListViewModel>
    {
        public int Id { get; set; }
    }
}
