using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Api.DTOs
{
    public class CreateShortUrlRequest
    {
        [Required]
        public string Url { get; set; } = string.Empty;
    }
}
