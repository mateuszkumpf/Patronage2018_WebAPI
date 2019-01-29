using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Patronage2018.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Rooms.Queries.GetAllRooms
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, RoomsListViewModel>
    {
        private readonly PatronageDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRoomsQueryHandler(PatronageDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomsListViewModel> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            return new RoomsListViewModel
            {
                Rooms = await _context.Rooms.ProjectTo<RoomLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
