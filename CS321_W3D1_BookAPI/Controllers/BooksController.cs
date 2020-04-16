using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //variable book, holds book data from database
            var book = _bookService.Get(id);

            //if var book has no value, return  404 Not Found
            if (book == null) return NotFound();

            //otherwise, return 200 OK message and the data within var book
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                _bookService.Post(book);
            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError("Add Book", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new {Id = book.Id }, book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book updatedBook)
        {
            var book = _bookService.Update(updatedBook);

            if (book == null) return NotFound();
            return Ok(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);

            if (book == null) return NotFound();
            
            _bookService.Delete(book);

            return NoContent();
            

        }
    }
}