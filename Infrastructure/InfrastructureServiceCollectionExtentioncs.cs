using Infrastructure.Mail;
using Infrastructure.Mail.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {

        public static IServiceCollection AddMailing(this IServiceCollection services, IHostEnvironment environment)
        {
            services.AddSingleton<IConfigureOptions<MailOptions>, MailConfigureOptions>();
            services.AddSingleton<IMailer, Mailer>();
            services.AddSingleton<IViewRenderer, ViewRenderer>();
            services.AddSingleton<IMailSender, SmtpSender>();
           

            return services;
        }
    }
}
