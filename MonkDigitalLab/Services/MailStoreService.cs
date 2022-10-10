using Microsoft.EntityFrameworkCore;
using MonkDigitalLab.Interfaces;
using MonkDigitalLab.Models;
using MonkDigitalLab.Models.Entities;

namespace MonkDigitalLab.Services
{
    /// <summary>
    /// Сервис хранения писем
    /// </summary>
    public class MailStoreService : IMailStoreService
    {
        private ApplicationContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст</param>
        public MailStoreService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение писем
        /// </summary>
        /// <returns>Коллекция писем</returns>
        public async Task<IEnumerable<Mail>> GetMailsAsync()
        {
            try
            {
                var foundMails = await _context.Mails
                    .ToListAsync();

                return foundMails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Добавление письма
        /// </summary>
        /// <param name="mail">Письмо</param>
        /// <returns>Созданное письмо</returns>
        public async Task<Mail> AddMailAsync(Mail mail)
        {
            try
            {
                var addedMail = await _context.Mails
                    .AddAsync(mail);

                await _context.SaveChangesAsync();

                return addedMail.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
