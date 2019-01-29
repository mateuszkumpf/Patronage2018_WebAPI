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

namespace Patronage2018.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomComandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly PatronageDbContext _context;
        private readonly IMediator _mediator;

        public DeleteRoomComandHandler(PatronageDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            _context.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CreateMailNotification
            {
                Subject = "Delete room",
                Body = $"Command remove that room:{Environment.NewLine}{entity.ToString()}"
            });

            return Unit.Value;
        }
    }
}
