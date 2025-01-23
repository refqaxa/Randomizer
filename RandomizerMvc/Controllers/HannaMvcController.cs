using Microsoft.AspNetCore.Mvc;
using RandomizerMvc.Models.HannaModels;
using System.Net.Http;

namespace RandomizerMVC.Controllers
{
    public class HannaMvcController : Controller
    {
        private readonly HttpClient _httpClient;

        public readonly int port = 5210;

        public HannaMvcController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RandomDateNoPara()
        {
            var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomDate/NoParameters");

            var date = await response.Content.ReadAsStringAsync();

            ViewBag.RandomDate = date;

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> RandomDateOnePara(RandomDateModel.OneParameter model)
        {
            if (ModelState.IsValid)
            {
                DateTime startDate = model.UserDateChoice;
                string formattedDate = startDate.ToString("yyyy-MM-dd");

                if (formattedDate == "0001-01-01")
                {
                    ViewBag.RandomDate = "Please provide a valid date";

                }
                else
                {
                    var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomDate/OneParameter?startDate={formattedDate}");
                    response.EnsureSuccessStatusCode();

                    var date = await response.Content.ReadAsStringAsync();
                    ViewBag.RandomDate = date;
                }
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> RandomDateTwoPara(RandomDateModel.TwoParameter model)
        {
            if (ModelState.IsValid)
            {
                var startDate = model.FirstUserDateChoice;

                var endDate = model.SecondUserDateChoice;

                if (startDate >= endDate)
                {
                    ViewBag.RandomDate = "De startdatum kan niet na de einddatum liggen.";
                }
                else
                {

                    var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomDate/TwoParameters?startDate={startDate}&endDate={endDate}");
                    response.EnsureSuccessStatusCode();
                    var date = await response.Content.ReadAsStringAsync();

                    ViewBag.RandomDate = date;
                }


            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RandomInt(RandomIntModel model)
        {
            bool UserChoice = model.UserChoice;

            if (UserChoice == true)
            {
                var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomInteger/allowNegative?allowNegative=true");
                var result = await response.Content.ReadAsStringAsync();

                ViewBag.RandomInt = $"Je willekeurig geheel getal is {result} ";
            }
            else
            {
                var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomInteger/allowNegative?allowNegative=false");
                var result = await response.Content.ReadAsStringAsync();

                ViewBag.RandomInt = $"Je willekeurig geheel getal is {result}";
            }

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> RandomPincode(RandomPinModel model)
        {
            if (ModelState.IsValid)
            {
                int lenght = model.UserChoice;
                var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomPincode/length?length={lenght}");
                response.EnsureSuccessStatusCode();
                var pincode = await response.Content.ReadAsStringAsync();

                ViewBag.RandomPin = pincode;

            }

            return View(model);
        }




        public async Task<IActionResult> RandomSeason()
        {
            var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomSeasons/RandomSeason");

            var Season = await response.Content.ReadAsStringAsync();

            ViewBag.RandomSeason = Season;

            return View();
        }

    }
}
