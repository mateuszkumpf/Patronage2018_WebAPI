using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Patronage2018.Application.Calendars.Queries.Models;
using Patronage2018.Application.Exceptions;
using Patronage2018.Domain.Entities;
using Patronage2018.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Calendars.Queries.GetRoomsCalendar
{
    public class GetRoomsCalendarQueryHandler : IRequestHandler<GetRoomsCalendarQuery, CalendarsListViewModel>
    {
        private readonly PatronageDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsCalendarQueryHandler(PatronageDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CalendarsListViewModel> Handle(GetRoomsCalendarQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            return new CalendarsListViewModel
            {
                Calendars = await _context.Calendars.ProjectTo<CalendarLoockupModel>(_mapper.ConfigurationProvider)
                                                                                            .Where(e => e.RoomName == entity.RoomName)
                                                                                            .ToListAsync(cancellationToken)
            };
        }
    }
}
