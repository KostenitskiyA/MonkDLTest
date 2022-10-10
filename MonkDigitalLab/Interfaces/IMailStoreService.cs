using MonkDigitalLab.Models.Entities;

namespace MonkDigitalLab.Interfaces
{
    /// <summary>
    /// Провайдер писем
    /// </summary>
    public interface IMailStoreService
    {
        /// <summary>
        /// Получение писем
        /// </summary>
        /// <returns>Коллекция писем</returns>
        public Task<IEnumerable<Mail>> GetMailsAsync();

        /// <summary>
        /// Добавление письма
        /// </summary>
        /// <param name="mail">Письмо</param>
        /// <returns>Созданное письмо</returns>
        public Task<Mail> AddMailAsync(Mail mail);
    }
}
