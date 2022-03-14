using System;
using System.Net.Mail;
using System.Threading.Tasks;


namespace Infrastructure.Mail
{
    /// <summary>
    /// <see cref="IMailer" /> implementation.
    /// </summary>
    public class Mailer : IMailer
    {
        private readonly IMailSender _mailSender;
        private readonly IViewRenderer _viewRenderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mailer" /> class.
        /// </summary>
        /// 
        /// <param name="mailSender">Mail sender.</param>
        /// <param name="viewRenderer">View renderer.</param>
        public Mailer(IMailSender mailSender, IViewRenderer viewRenderer)
        {
            _mailSender = mailSender;
            _viewRenderer = viewRenderer;
        }

        /// <inheritdoc />
        public async Task SendAsync<T>(T model, string view, MailMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var body = await RenderAsync(view, model);

            message.IsBodyHtml = true;
            message.Body = body;
            message.Priority = MailPriority.High;
            await _mailSender.SendAsync(message);
        }

        /// <summary>
        /// Compiles a razor view.
        /// </summary>
        /// 
        /// <param name="viewName">View name.</param>
        /// <param name="model">View model.</param>
        protected virtual async Task<string> RenderAsync(string viewName, object model)
        {
            return await _viewRenderer.RenderAsync(viewName, model);
        }
    }
}
