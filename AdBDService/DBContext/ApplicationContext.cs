using AdJson.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace AdDBService.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasComment("Сущность пользователя");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентификатор пользователя");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("Имя пользователя");

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("BIT")
                    .HasColumnName("is_admin")
                    .HasComment("Является ли администратором");
            });

            modelBuilder.Entity<Advert>(entity =>
            {
                entity.ToTable("Adverts");

                entity.HasComment("Сущность объявления");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентификатор объявления");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasComment("Номер объявления");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasComment("Текст объявления");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasComment("Обложка объявления");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasComment("Рейтинг объявления");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("Дата создания объявления");

                entity.Property(e => e.DateExp)
                    .HasColumnName("date_exp")
                    .HasComment("Дата истечения срока объявления");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("Идентификатор пользователя, добавившего объявление");
            });
        }
    }
}
