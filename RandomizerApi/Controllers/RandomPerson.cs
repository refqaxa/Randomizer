using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomizerClassLibrary;

namespace RandomizerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomPersonController : ControllerBase
    {
        [HttpGet("generate/{selection}")]
        public ActionResult<string> GetRandomPerson(string selection)
        {
            if (!IsValidSelection(selection))
            {
                return BadRequest("Invalid selection. Please choose 'student', 'teacher', or 'person'.");
            }

            string generatedText = RefqaRandomProjects.GetRandomPersonJson(selection);
            return generatedText;
        }

        private bool IsValidSelection(string selection)
        {
            // Valid options: 'student', 'teacher', 'person'
            string[] validOptions = { "student", "teacher", "person" };

            // Check if the provided selection is in the valid options array
            return validOptions.Contains(selection.ToLower());
        }
    }
}
