using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mail.Configuration
{
    public class MailOptions
    {
        public string? Host { get; internal set; }
        public int Port { get; internal set; }
        public bool UseSsl { get; internal set; }
        public string? Login { get; internal set; }
        public SecureString? Password { get; internal set; }
    }
}
