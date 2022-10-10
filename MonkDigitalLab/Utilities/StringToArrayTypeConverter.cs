using AutoMapper;

namespace MonkDigitalLab.Utilities
{
    /// <summary>
    /// Конвертер строки в массив строк
    /// </summary>
    public class StringToArrayTypeConverter : ITypeConverter<string, IEnumerable<string>>
    {
        /// <summary>
        /// Конвертер строки в массив строк
        /// </summary>
        /// <param name="source">Источник конвертации</param>
        /// <param name="destination">Цель конвертации</param>
        /// <param name="context">Контекст</param>
        /// <returns>Коллекция строк</returns>
        public IEnumerable<string> Convert(string source, IEnumerable<string> destination, ResolutionContext context)
        {
            try
            {
                return source.Split(";");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
