using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shortify.Models;
using Shortify.Library;

namespace Shortify.Controllers
{
    [Route("")]
    [ApiController]
    public class URLController : ControllerBase
    {
        private readonly URLContext Context;
        private readonly string[] Reserved = { "api", "swagger" };

        private async Task<URL> AddURLToDatabase(string shortUrlId, string normalizedLongUrl)
        {
            var newUrl = new URL
            {
                Created = DateTime.Now,
                Identifier = shortUrlId,
                LongURL = normalizedLongUrl,
                ShortURL = $"shortify.link/{shortUrlId}"
            };

            await Context.AddAsync(newUrl);
            await Context.SaveChangesAsync();

            return newUrl;
        }

        public URLController(URLContext context)
        {
            Context = context;
        }

        [HttpGet("{identifier}", Name = "Get")]
        public async Task<IActionResult> GetLongURLByIdentifier(string identifier)
        {
            var url = await Context.URLs.FindAsync(identifier);

            if (url == null)
            {
                return NotFound();
            }
            else
            {
                ++url.TimesAccessed;
                await Context.SaveChangesAsync();
                return Redirect(url.LongURL);
            }
        }

        [HttpPost("api/v1/new", Name = "New")]
        public async Task<IActionResult> CreateURL([FromBody] CreateURLRequest request)
        {
            try
            {
                string normalizedLongUrl = URLNormalizer.Normalize(request.URL);

                if (!string.IsNullOrEmpty(request.CustomPath))
                {
                    if (!Uri.IsWellFormedUriString(request.CustomPath, UriKind.RelativeOrAbsolute))
                    {
                        return BadRequest("Invalid custom URL");
                    }
                    var custom = await Context.URLs.FindAsync(request.CustomPath);
                    if (custom != null || Reserved.Contains(request.CustomPath.ToLower()))
                    {
                        return BadRequest("URL identifier already exists");
                    }
                    else
                    {
                        var newCustomUrl = await AddURLToDatabase(request.CustomPath, normalizedLongUrl);
                        return CreatedAtAction(nameof(CreateURL), newCustomUrl);
                    }
                }

                var existingUrl = Context.URLs.FirstOrDefault(x => x.LongURL == normalizedLongUrl);
                if (existingUrl != null)
                {
                    return Ok(existingUrl);
                }

                var random = new Random();
                string shortUrlId;
                do
                {
                    var randomId = random.Next();
                    shortUrlId = URLShortener.Encode(randomId);
                } while (Context.URLs.Find(shortUrlId) != null);

                var newUrl = await AddURLToDatabase(shortUrlId, normalizedLongUrl);

                return CreatedAtAction(nameof(CreateURL), newUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
