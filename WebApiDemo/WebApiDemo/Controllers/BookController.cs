using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Modals;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook _book;

        public BookController(IBook book)
        {
            _book = book;

        }
        [HttpGet]
        public List<Book> Get()
        {
            return _book.GetAllBook();
        }

        // GET: api/Home/5
        [HttpGet("{Title}")]
        public ActionResult<List<Book>> Get([FromHeader]string Title)
        {
            var book = _book.GetBookByName(Title);
            if (book==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }

        }

        // POST: api/Home
        [HttpPost]
        public ActionResult Post([FromBody]Book book) 
        {
            _book.AddBook(book);
            return Ok();
            

        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public ActionResult Put(string name, Book book)
        {

            _book.UpdateBook(name, book);
            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
