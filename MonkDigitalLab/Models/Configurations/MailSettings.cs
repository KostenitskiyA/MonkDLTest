namespace MonkDigitalLab.Models.Configurations
{
    /// <summary>
    /// Настройки почты
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Сетевой протокол
        /// </summary>
        public string SMTPDomen { get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Протокол связи
        /// </summary>
        public bool SSL { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
