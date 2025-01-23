using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomText : ControllerBase
    {
        [HttpGet("generate/{numberOfParagraphs}/{isDutch}/{asHtml}")]
        public ActionResult<string> GenerateText(byte numberOfParagraphs, bool isDutch, bool asHtml)
        {
            string generatedText = RefqaRandomProjects.GenerateRandomText(numberOfParagraphs, isDutch, asHtml);
            return generatedText;
        }
    }
}
