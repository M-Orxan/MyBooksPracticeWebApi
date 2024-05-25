using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data;
using MyBooks.Data.Models;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }


        [HttpPost("Add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
        {
            _authorsService.AddAuthor(authorVM);
            return Ok();

        }



        [HttpGet("Get-all authors")]

        public IActionResult GetAllAuthors()
        {
           List<Author> authors= _authorsService.GetAllAuthors();
            return Ok(authors);

        }


        [HttpGet("Get-author-by-id/{id}")]

        public IActionResult GetAllAuthors(int id)
        {
            Author author = _authorsService.GetAuthorById(id);
            return Ok(author);

        }


        [HttpPut("Update-author-by-id/{id}")]

        public IActionResult UpdateAuthorById(int id, AuthorVM newAuthor)
        {
            Author author = _authorsService.UpdateAuthorById(id, newAuthor);
            return Ok(author);

        }


        [HttpDelete("Delete-author-by-id/{id}")]

        public IActionResult DeleteAuthorById(int id)
        {
           _authorsService.DeletAuthorById(id);

            return Ok();

        }


    }
}
