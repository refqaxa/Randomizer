using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomPasswordController : ControllerBase
    {
        [HttpGet("OnePara")]
        public ActionResult<int> GenerateRandomPassword(int length)
        {
            string result = JosRandomProjects.RandomPassword(length);
            return Ok(result);
        }


        [HttpGet("FivePara")]
        public ActionResult<string> GenerateRandomPassword(int length, bool useUpperCase, bool useLowerCase, bool useNumbers, bool useSpecialCharacters)
        {
            string result = JosRandomProjects.RandomPassword(length, useUpperCase, useLowerCase, useNumbers, useSpecialCharacters);
            return Ok(result);
        }
        [HttpGet("FourPara")]
        public ActionResult<string> GenerateRandomPassword(byte useUpperCase, byte useLowerCase, byte useNumbers, byte useSpecialCharacters)
        {
            string result = JosRandomProjects.RandomPassword(useUpperCase, useLowerCase, useNumbers, useSpecialCharacters);
            return Ok(result);
        }

    }


}