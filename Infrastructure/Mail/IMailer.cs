using System.Net.Mail;

namespace Infrastructure.Mail
{
    /// <summary>
    /// Mailer module.
    /// </summary>
    public interface IMailer
    {
        /// <summary>
        /// Sends an email.
        /// </summary>
        /// 
        /// <typeparam name="T">Model type.</typeparam>
        /// 
        /// <param name="model">Model object.</param>
        /// <param name="view">View name.</param>
        /// <param name="message">Mail message to send.</param>
        Task SendAsync<T>(T model, string view, MailMessage message);
    }
}
