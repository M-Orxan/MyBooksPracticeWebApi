using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Models;
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


        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
           List<Book> books= _bookService.GetAllBooks();
            return Ok(books);
        }


        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
           Book book= _bookService.GetBookById(id);
            return Ok(book);
        }
    }
}
