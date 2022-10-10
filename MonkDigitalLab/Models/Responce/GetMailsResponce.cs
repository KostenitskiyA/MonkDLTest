using MonkDigitalLab.Models.Entities;

namespace MonkDigitalLab.Models.Responce
{
    /// <summary>
    /// Ответ получения писем
    /// </summary>
    public class GetMailsResponce
    {
        /// <summary>
        /// Отправитель
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело письма
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Коллекция получателей
        /// </summary>
        public IEnumerable<string> Recipients { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Результат
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
