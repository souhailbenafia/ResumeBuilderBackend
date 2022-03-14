using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Infrastructure.Mail.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Mail
{
    /// <summary>
    /// Smtp mail sender.
    /// </summary>
    public class SmtpSender : IMailSender
    {
        private readonly MailOptions _options;
        private readonly SmtpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpSender" /> client.
        /// </summary>
        /// 
        /// <param name="options">Mail options.</param>
        public SmtpSender(IOptions<MailOptions> options)
        {
            _options = options.Value;
            _client = new SmtpClient(_options.Host, _options.Port);
        }

        /// <inheritdoc />
        public async Task SendAsync(MailMessage message)
        {
            _client.Credentials = new NetworkCredential(_options.Login, _options.Password);
            _client.EnableSsl = _options.UseSsl;
            await _client.SendMailAsync(message);
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client?.Dispose();
            }
        }

        #endregion
    }
}
