using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomSeasonsController : ControllerBase
    {
        [HttpGet("RandomSeason")]
        public ActionResult<string> GenerateRandomSeason()
        {
            Season randomSeason = HannaRandomProjects.GenerateRandomSeason();
            string seasonAsString = randomSeason.ToString();
            return seasonAsString;
        }

    }
}
