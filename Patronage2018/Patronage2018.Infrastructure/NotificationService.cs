using Patronage2018.Application.Interfaces;
using Patronage2018.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace Patronage2018.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
