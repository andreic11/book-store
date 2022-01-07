using LibraryAPI.DTO;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // POST: api/Books
        [HttpPost("create")]
        public IActionResult Create(BookDTO book)
        {
            var response = _bookService.Create(book);

            return Ok(response);
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // PUT: api/Books/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, BookDTO book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            var response = await _bookService.Update(book);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // DELETE: api/Books/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookService.Delete(id);
            return NoContent();
        }
    }
}
