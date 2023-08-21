using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdService.Models
{
    public class Advert
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string? Text { get; set; }

        public byte[]? Picture { get; set; }

        public int Rate { get; set; }

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime DateExp { get; set; }

        public Guid UserId { get; set; }
    }
}