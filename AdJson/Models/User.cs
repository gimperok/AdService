using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AdJson.Interfaces;

namespace AdJson.Models
{
    /////<inheritdoc cref="IUser"/>
    /// <summary>
    /// Сущность пользователя
    /// </summary>
    public class User : IUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Name { get; set; }

        public bool IsAdmin { get; set; }

        public List<Advert> Adverts { get; set; } = new();
    }
}