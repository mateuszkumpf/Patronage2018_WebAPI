using MediatR;
using Patronage2018.Application.Exceptions;
using Patronage2018.Application.Notifications;
using Patronage2018.Domain.Entities;
using Patronage2018.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Rooms.Commands.UpdateRoom
{
    class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly PatronageDbContext _context;
        private readonly IMediator _mediator;

        public UpdateRoomCommandHandler(PatronageDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            var before = entity.ToString();

            entity.RoomName = request.RoomName;

            var after = entity.ToString();

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CreateMailNotification
            {
                Subject = "Update calendar",
                Body = $"Before:{Environment.NewLine}{Environment.NewLine}{before}" +
                       $"{Environment.NewLine}{Environment.NewLine}" +
                       $"After:{Environment.NewLine}{Environment.NewLine}{after}"
            });

            return Unit.Value;
        }
    }
}
