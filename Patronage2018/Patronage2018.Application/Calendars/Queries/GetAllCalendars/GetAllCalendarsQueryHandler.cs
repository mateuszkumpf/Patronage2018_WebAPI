using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Patronage2018.Application.Calendars.Queries.Models;
using Patronage2018.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Calendars.Queries.GetAllCalendars
{
    public class GetAllCalendarsQueryHandler : IRequestHandler<GetAllCalendarsQuery, CalendarsListViewModel>
    {
        private readonly PatronageDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCalendarsQueryHandler(PatronageDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CalendarsListViewModel> Handle(GetAllCalendarsQuery request, CancellationToken cancellationToken)
        {
            return new CalendarsListViewModel
            {
                Calendars = await _context.Calendars.ProjectTo<CalendarLoockupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
