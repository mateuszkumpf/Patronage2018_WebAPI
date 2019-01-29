using MediatR;
using Patronage2018.Application.Exceptions;
using Patronage2018.Domain.Entities;
using Patronage2018.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Rooms.Queries.GetRoom
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomDetailModel>
    {
        private readonly PatronageDbContext _context;

        public GetRoomQueryHandler(PatronageDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDetailModel> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            return new RoomDetailModel
            {
                Id = entity.RoomId,
                Name = entity.RoomName
            };
        }
    }
}
