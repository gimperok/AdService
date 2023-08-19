namespace AdService.Models
{
    public class Advert
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string? Text { get; set; }
        public byte[]? Picture { get; set; }
        public int Rate { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateExp { get; set; }

        public Guid UserGuid { get; set; }

    }
}