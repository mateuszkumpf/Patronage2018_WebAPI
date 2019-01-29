using MediatR;
using Patronage2018.Application.Interfaces;
using Patronage2018.Application.Notifications;
using Patronage2018.Domain.Entities;
using Patronage2018.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Calendars.Commands.CreateCalendar
{
    public class CreateCalendarCommandHandler : IRequestHandler<CreateCalendarCommand, int>
    {
        private readonly PatronageDbContext _context;
        private readonly IMediator _mediator;

        public CreateCalendarCommandHandler(PatronageDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var entity = new Calendar
            {
                RoomId = request.RoomId,
                From = request.From,
                To = request.To
            };

            _context.Calendars.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CreateMailNotification { Subject = "Create calendar", Body = entity.ToString() });

            return entity.CalendarId;
        }
    }
}
