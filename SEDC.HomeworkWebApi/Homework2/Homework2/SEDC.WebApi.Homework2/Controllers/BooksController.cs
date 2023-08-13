using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Homework2.Models;

namespace SEDC.WebApi.Homework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("{index}")]
        public ActionResult GetSingle(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("Wrong input. Cannot type negative number. ");
                }

                return Ok(StaticDb.Books[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error. Please try again. ");
            }
        }

        [HttpGet("{title}/filter/{author}")]
        public ActionResult<List<Book>> FilterBooks(string? title, string? author)
        {
            try
            {
                if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(author))
                {
                    return BadRequest("Please insert at least one parameter. ");
                }
                if (string.IsNullOrEmpty(title))
                {
                    return Ok(StaticDb.Books.Where(x => x.Title.ToLower() == title.ToLower()).ToList());
                }
                if (string.IsNullOrEmpty(author))
                {
                    return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower()).ToList());
                }

                return Ok(StaticDb.Books.Where(x => x.Title.ToLower() == title.ToLower() && x.Author.ToLower() == author.ToLower()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, try again later. ");
            }
        }

        [HttpPost]
        public IActionResult AddNote([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("You have to insert Title and Author. ");
                }

                StaticDb.Books.Add(book);

                return Ok("Book added succesfully");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured. Please try again later. ");
            }

        }
    }
}
