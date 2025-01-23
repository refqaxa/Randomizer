using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomPincodeController : ControllerBase
    {
        [HttpGet("length")]
        public ActionResult<int> GenerateRandomPin(int length)
        {
            string result = HannaRandomProjects.GenerateRandomPin(length);
            return Ok(result);
        }
    }
}
