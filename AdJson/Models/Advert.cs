
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AdJson.Interfaces;

namespace AdJson.Models
{
    ///<inheritdoc cref="IAdvert"/>
    public class Advert : IAdvert
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string? Text { get; set; }

        public string? Picture { get; set; }

        public int Rate { get; set; }

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime DateExp { get; set; }

        public Guid UserId { get; set; }
    }
}