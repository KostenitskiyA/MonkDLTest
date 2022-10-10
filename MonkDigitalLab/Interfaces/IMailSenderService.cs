using MonkDigitalLab.Models.Entities;

namespace MonkDigitalLab.Interfaces
{
    /// <summary>
    /// Сервис отправки писем
    /// </summary>
    public interface IMailSenderService
    {
        /// <summary>
        /// Отправка письма
        /// </summary>
        /// <param name="mail">Письмо</param>
        /// <param name="recipients">Коллекция получателей</param>
        /// <returns>Отправленное письмо</returns>
        public Task<Mail> SendEmailAsync(Mail mail, IEnumerable<string> recipients);
    }
}
