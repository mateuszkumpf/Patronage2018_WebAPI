using Patronage2018.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patronage2018.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
