using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomDice : ControllerBase
    {
        [HttpGet("roll/{numberOfDice}")]
        public ActionResult<int[]> RollDice(int numberOfDice)
        {
            int[] rolls = RefqaRandomProjects.GenerateRandomDiceRolls(numberOfDice);
            return rolls;
        }
    }
}
