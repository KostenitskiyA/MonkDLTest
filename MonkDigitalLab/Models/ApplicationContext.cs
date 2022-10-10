using Microsoft.EntityFrameworkCore;
using MonkDigitalLab.Models.Entities;

namespace MonkDigitalLab.Models
{
    // Контекст базы данных
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Письма
        /// </summary>
        public DbSet<Mail> Mails { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options">Настройки</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mail>().Property(m => m.CreateDate).HasComputedColumnSql("getdate()");
        }
    }
}
