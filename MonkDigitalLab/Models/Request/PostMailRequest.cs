namespace MonkDigitalLab.Models.Request
{
    /// <summary>
    /// Запрос отправки письма
    /// </summary>
    public class PostMailRequest
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
    }
}
