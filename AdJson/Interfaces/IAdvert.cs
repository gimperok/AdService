
namespace AdJson.Interfaces
{
    public interface IAdvert
    {
        /// <summary>
        /// Идентификатор объявления
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номем объявления
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Текст объявления
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Адрес обложки объявления
        /// </summary>
        public string? Picture { get; set; }

        /// <summary>
        /// Рейтинг объявления
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Дата создания объявления
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Дата истечения срока объявления
        /// </summary>
        public DateTime DateExp { get; set; }

        /// <summary>
        /// Идентификатор пользователя, добавившего объявление
        /// </summary>
        public Guid UserId { get; set; }
    }
}