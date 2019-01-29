using MediatR;
using Patronage2018.Application.Exceptions;
using Patronage2018.Application.Notifications;
using Patronage2018.Domain.Entities;
using Patronage2018.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Calendars.Commands.DeleteCalendar
{
    public class DeleteCalendarCommandHandler : IRequestHandler<DeleteCalendarCommand, Unit>
    {
        private readonly PatronageDbContext _context;
        private readonly IMediator _mediator;

        public DeleteCalendarCommandHandler(PatronageDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteCalendarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Calendars.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Calendar), request.Id);
            }

            _context.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CreateMailNotification
            {
                Subject = "Delete calendar",
                Body = $"Command remove that calendar:{Environment.NewLine}{entity.ToString()}"
            });

            return Unit.Value;
        }
    }
}
