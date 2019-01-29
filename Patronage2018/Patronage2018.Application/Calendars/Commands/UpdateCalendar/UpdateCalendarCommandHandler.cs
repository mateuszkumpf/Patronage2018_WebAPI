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

namespace Patronage2018.Application.Calendars.Commands.UpdateCalendar
{
    public class UpdateCalendarCommandHandler : IRequestHandler<UpdateCalendarCommand, Unit>
    {
        private readonly PatronageDbContext _context;
        private readonly IMediator _mediator;

        public UpdateCalendarCommandHandler(PatronageDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCalendarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Calendars.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Calendar), request.Id);
            }

            var before = entity.ToString();

            entity.From = request.From;
            entity.To = request.To;

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
