using UrlShortener.Api.Data;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Services
{
    public class UrlService
    {
        private readonly AppDbContext _context;

        public UrlService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ShortUrl> CreateShortUrl(string originalUrl)
        {
            var shortCode = GenerateShortCode();

            var url = new ShortUrl
            {
                OriginalUrl = originalUrl,
                ShortCode = shortCode
            };

            _context.ShortUrls.Add(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public ShortUrl GetByCode(string code)
        {
            return _context.ShortUrls.FirstOrDefault(x => x.ShortCode == code);
        }

        private string GenerateShortCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}