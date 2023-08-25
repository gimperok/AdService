
namespace AdJson.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Является ли администратором
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}