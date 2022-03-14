using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Mail
{
    /// <summary>
    /// Mail sender.
    /// </summary>
    public interface IMailSender : IDisposable
    {
        /// <summary>
        /// Sends an email message.
        /// </summary>
        /// 
        /// <param name="message">Message to send.</param>
        Task SendAsync(MailMessage message);
    }
}
