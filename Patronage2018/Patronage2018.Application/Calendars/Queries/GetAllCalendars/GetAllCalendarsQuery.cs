using MediatR;
using Patronage2018.Application.Calendars.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Calendars.Queries.GetAllCalendars
{
    public class GetAllCalendarsQuery : IRequest<CalendarsListViewModel>
    {

    }
}
