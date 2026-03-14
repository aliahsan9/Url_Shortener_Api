using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Api.Models
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OriginalUrl { get; set; } = string.Empty;
        [Required]
        public string ShortCode { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public int ClickCount { get; set; } = 0;

    }
}
