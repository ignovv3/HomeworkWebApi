using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            return Ok(StaticDb.Names);
        }

        [HttpGet("{index}")]
        public ActionResult<string> GetByIndex(int index)
        {
            try
            {
                if(index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"The index {index} is a negative number.");
                }
                if(index >= StaticDb.Names.Count)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"The index {index} was not found.");
                }

                return Ok(StaticDb.Names[index]);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error try again later.");
            }
        }
    }
}
