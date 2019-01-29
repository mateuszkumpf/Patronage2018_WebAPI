using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Notifications.Models
{
    public class MailSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Password { get; set; }
    }
}
