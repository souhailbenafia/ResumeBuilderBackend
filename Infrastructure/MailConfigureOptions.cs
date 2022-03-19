using Infrastructure.Mail.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class MailConfigureOptions : IConfigureOptions<MailOptions>
    {
        public void Configure(MailOptions options)
        {
           options.Host = "localhost";
            options.Port = 4040;
            options.UseSsl = true;
            options.Login = "";
        }
    }
}