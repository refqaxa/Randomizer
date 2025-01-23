using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomTimeController : ControllerBase
    {
        [HttpGet("Time")]
        public ActionResult<int> GenerateRandomTime()
        {
            JosRandomProjects.Time result = JosRandomProjects.RandomTime();
            string formattedHour = result.Hour.ToString("00");
            string formattedMinute = result.Minute.ToString("00");
            string formattedSecond = result.Second.ToString("00");

            return Ok($"{formattedHour} : {formattedMinute} : {formattedSecond}");
        }

    }


}
