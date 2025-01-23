using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomFirstNames : ControllerBase
    {
        [HttpGet("generate/{includeBoysNames}/{includeGirlsNames}/{numberOfNames}")]
        public ActionResult<string[]> GenerateNames(bool includeBoysNames, bool includeGirlsNames, int numberOfNames)
        {
            string[] generatedNames = RefqaRandomProjects.GenerateRandomNames(includeBoysNames, includeGirlsNames, numberOfNames);
            return generatedNames;
        }
    }

}
