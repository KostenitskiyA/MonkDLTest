using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MonkDigitalLab.Interfaces;
using MonkDigitalLab.Models.Configurations;
using MonkDigitalLab.Models.Entities;

namespace MonkDigitalLab.Services
{
    /// <summary>
    /// Сервис отправки писем
    /// </summary>
    public class MailSenderService : IMailSenderService
    {
        private MailSettings _mailSettings;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mailSettings">Настройки почты</param>
        public MailSenderService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        /// <summary>
        /// Отправка письма
        /// </summary>
        /// <param name="mail">Письмо</param>
        /// <param name="recipients">Коллекция получателей</param>
        /// <returns>Отправленное письмо</returns>
        public async Task<Mail> SendEmailAsync(Mail mail, IEnumerable<string> recipients)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(
                        _mailSettings.SMTPDomen,
                        _mailSettings.Port,
                        _mailSettings.SSL);

                    await client.AuthenticateAsync(
                        _mailSettings.Login,
                        _mailSettings.Password);

                    foreach (var recipient in recipients)
                    {
                        var email = new MimeMessage();

                        email.From.Add(new MailboxAddress(
                            _mailSettings.Name,
                            _mailSettings.Login));

                        email.To.Add(new MailboxAddress(
                            "",
                            recipient));

                        email.Subject = mail.Subject;
                        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                        {
                            Text = mail.Body
                        };

                        await client.SendAsync(email);
                    }

                    await client.DisconnectAsync(true);
                }

                return mail;
            }
            catch (Exception exception)
            {
                mail.Result = ResultType.Failed;
                mail.FailedMessage = exception.Message;

                return mail;
            }
        }
    }
}
