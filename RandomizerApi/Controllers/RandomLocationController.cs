using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomLocationController : ControllerBase
    {
        [HttpGet("RandomLocation")]
        public ActionResult<int> GenerateRandomLocation()
        {
            string result = JosRandomProjects.RandomLocation();
            return Ok(result);
        }

    }


}
