using MediatR;
using Patronage2018.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Patronage2018.Domain.Entities;
using Patronage2018.Application.Notifications;

namespace Patronage2018.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly PatronageDbContext _context;
        private readonly IMediator _mediator;

        public CreateRoomCommandHandler(PatronageDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new Room
            {
                RoomName = request.Name,
            };

            _context.Rooms.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CreateMailNotification { Subject = "Create room", Body = entity.ToString() });

            return entity.RoomId;
        }
    }
}
