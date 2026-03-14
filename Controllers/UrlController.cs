using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using UrlShortener.Api.DTOs;
using UrlShortener.Api.Models;
using UrlShortener.Api.Services;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly UrlService _service;
        public UrlController(UrlService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateShortUrl(CreateShortUrlRequest request)
        {
            var result = await _service.CreateShortUrl(request.Url);

            var shortUrl = $"{Request.Scheme}://{Request.Host}/{result.ShortCode}";

            return Ok(new CreateShortUrlResponse
            {
                ShortUrl = shortUrl
            });
        }  
        [HttpGet("/{code}")]
        public IActionResult RedirectionToOriginal(string code)
        {
            var url = _service.GetByCode(code);

            if (url == null)
            {
                return NotFound();
            }
            return Redirect(url.OriginalUrl);
        }
    }
}
