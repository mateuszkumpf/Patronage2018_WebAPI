using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Notifications.Models
{
    public class Message
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
