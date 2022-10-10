using AutoMapper;

namespace MonkDigitalLab.Utilities
{
    /// <summary>
    /// AutoMapper помощник
    /// </summary>
    public static class AutoMapperUtility<F, T>
    {
        /// <summary>
        /// Преобразование
        /// </summary>
        /// <param name="from">Преобразуемый объект</param>
        /// <returns>Преобразованный объект</returns>
        public static T Map(F from)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<F, T>());
                var mapper = config.CreateMapper();
                var todoRequest = mapper.Map<T>(from);

                return todoRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
