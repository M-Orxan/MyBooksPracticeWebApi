using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Models;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("Add-publisher")]

        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }


        [HttpGet("Get-all publishers")]

        public IActionResult GetAllPublishers()
        {
            List<Publisher> publishers = _publishersService.GetAllPublishers();
            return Ok(publishers);

        }


        [HttpGet("Get-publisher-by-id/{id}")]

        public IActionResult GetAllPublishers(int id)
        {
            Publisher publisher = _publishersService.GetPublisherById(id);
            return Ok(publisher);

        }


        [HttpPut("Update-publisher-by-id/{id}")]

        public IActionResult UpdatePublisherById(int id, PublisherVM newPublisher)
        {
            Publisher publisher = _publishersService.UpdatePublisherById(id, newPublisher);
            return Ok(publisher);

        }


        [HttpDelete("Delete-publisher-by-id/{id}")]

        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);

            return Ok();

        }

    }
}
