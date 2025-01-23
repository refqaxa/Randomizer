using Microsoft.AspNetCore.Mvc;

namespace RandomizerMvc.Controllers
{
    public class WesleyMvcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
