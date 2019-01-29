using MediatR;
using Patronage2018.Application.Interfaces;
using Patronage2018.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Notifications
{
    //public class CreateMailNotificationHandler : INotificationHandler<CreateMailNotification>
    //{
    //    private readonly INotificationService _notificationService;

    //    public CreateMailNotificationHandler(INotificationService notification)
    //    {
    //        _notificationService = notification;
    //    }

    //    public async Task Handle(CreateMailNotification notification, CancellationToken cancellationToken)
    //    {
    //        await _notificationService.SendAsync(new Message { Subject = notification.Subject, Body = notification.Body });
    //    }
    //}
}
