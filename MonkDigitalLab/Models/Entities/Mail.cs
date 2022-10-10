namespace MonkDigitalLab.Models.Entities
{
    /// <summary>
    /// Модель письма
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Тело письма
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// Коллекция получателей
        /// </summary>
        public string Recipients { get; set; } = string.Empty;

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Результат
        /// </summary>
        public ResultType Result { get; set; } = ResultType.OK;

        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        public string FailedMessage { get; set; } = string.Empty;
    }

    /// <summary>
    /// Тип результата
    /// </summary>
    public enum ResultType
    {
        OK,
        Failed
    }
}
