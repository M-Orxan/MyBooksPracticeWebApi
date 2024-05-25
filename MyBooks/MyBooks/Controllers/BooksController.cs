using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]

        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }
    }
}
