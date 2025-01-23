using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomDateController : ControllerBase
    {
        [HttpGet("NoParameters")]
        public ActionResult<string> GetRandomDateNoPara()
        {
            try
            {
                DateTime randomDate = HannaRandomProjects.RandomDateNoPara();
                string formattedDate = randomDate.ToString("yyyy-MM-dd");
                return Ok(formattedDate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");

            }
        }



        [HttpGet("OneParameter")]
        public ActionResult<string> RandomDateOnePara(DateTime startDate)
        {
            try
            {
                DateTime randomDate = HannaRandomProjects.RandomDateOnePara(startDate);
                string formattedDate = randomDate.ToString("yyyy-MM-dd");
                return Ok(formattedDate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("TwoParameters")]
        public ActionResult<string> RandomDateTwoPara(DateTime startDate, DateTime endDate)
        {
            try
            {
                DateTime randomDate = HannaRandomProjects.RandomDateTwoPara(startDate, endDate);
                string formattedDate = randomDate.ToString("yyyy-MM-dd");
                return Ok(formattedDate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }


}