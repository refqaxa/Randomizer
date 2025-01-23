using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomIntegerController : ControllerBase
    {
        [HttpGet("allowNegative")]
        public ActionResult<int> GenerateRandomInteger(bool allowNegative)
        {
            try
            {
                int result = HannaRandomProjects.GenerateRandomInteger(allowNegative);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");

            }
        }
    }
}
