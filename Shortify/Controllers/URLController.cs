using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shortify.Models;

namespace Shortify.Controllers
{
    [Route("")]
    [ApiController]
    public class URLController : ControllerBase
    {
        private readonly URLContext _context;

        public URLController(URLContext context)
        {
            _context = context;
            if (_context.URLs.Count() == 0)
            {
                _context.URLs.Add(new URL
                {
                    Created = DateTime.Now,
                    Identifier = "CountryDuck",
                    LongURL = "https://google.com/",
                    ShortURL = "shortify.link/CountryDuck"
                }
                );
                _context.SaveChanges();
            }
        }

        // GET: api/URL
        [HttpGet("{identifier}", Name = "Get")]
        public ActionResult<URL> GetLongURLByIdentifier(string identifier)
        {
            var url = _context.URLs.Find(identifier);

            if (url == null)
            {
                return NotFound();
            }
            else
            {
                return Redirect(url.LongURL);
            }
        }

        //// GET: api/URL/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/URL
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/URL/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
