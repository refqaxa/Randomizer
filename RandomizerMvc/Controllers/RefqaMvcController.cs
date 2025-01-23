using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RandomizerMvc.Models.RefqaModels;

namespace RandomizerMvc.Controllers
{
    public class RefqaMvcController : Controller
    {
        private readonly HttpClient _httpClient;

        public RefqaMvcController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7116/");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RollDice(int numberOfDice)
        {
            if (numberOfDice < 1)
            {
                ViewBag.TooSmall = "Invalid input!";
                return View();
            }

            try
            {
                var response = await _httpClient.GetAsync($"api/RandomDice/roll/{numberOfDice}");
                response.EnsureSuccessStatusCode();

                int[] rolls = await response.Content.ReadAsAsync<int[]>();
                return View(rolls);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.TooSmall = "Invalid input!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult RandomText()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateText(RandomTextModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.GetAsync($"api/RandomText/generate/{model.ParagraphsAmount}/{model.InDutch}/{model.AsHtml}");
                    response.EnsureSuccessStatusCode();

                    string generatedText = await response.Content.ReadAsStringAsync();
                    ViewBag.GeneratedText = generatedText;
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.TooSmall = "Invalid input!";
                }
            }

            return View("RandomText", model);
        }

        [HttpGet]
        public IActionResult RandomFirstNames()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateNames(RandomFirstNames model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.GetAsync($"api/RandomFirstNames/generate/{model.IncludeBoysNames}/{model.IncludeGirlsNames}/{model.NumberOfNames}");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    string[] generatedNames = JsonConvert.DeserializeObject<string[]>(responseBody);
                    ViewBag.GeneratedNames = generatedNames;
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.TooSmall = "Invalid input!";
                }
            }

            return View("RandomFirstNames", model);

        }

        [HttpGet]
        public IActionResult RandomStudentOrTeacher()
        {
            ViewData["PersonTypeOptions"] =new List<string> { "student", "teacher", "person" };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePerson(RandomPerson model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.GetAsync($"api/RandomPerson/generate/{model.PersonType}");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    ViewBag.GeneratedPerson = responseBody;
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.TooSmall = "Invalid input!";
                }
            }

            // Pass the PersonTypeOptions to the view
            ViewBag.PersonTypeOptions = model.PersonTypeOptions;

            return View("RandomStudentOrTeacher", model);
        }

    }
}
