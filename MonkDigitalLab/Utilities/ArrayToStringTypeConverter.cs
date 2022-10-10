using AutoMapper;

namespace MonkDigitalLab.Utilities
{
    /// <summary>
    /// Конвертер массива строк в строку
    /// </summary>
    public class ArrayToStringTypeConverter : ITypeConverter<IEnumerable<string>, string>
    {
        /// <summary>
        /// Конвертер массива строк в строку
        /// </summary>
        /// <param name="source">Источник конвертации</param>
        /// <param name="destination">Цель конвертации</param>
        /// <param name="context">Контекст</param>
        /// <returns>Строка</returns>
        public string Convert(IEnumerable<string> source, string destination, ResolutionContext context)
        {
            try
            {
                return string.Join(";", source);
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
