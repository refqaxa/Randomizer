using Microsoft.AspNetCore.Mvc;
using RandomizerMvc.Models.HannaModels;
using RandomizerMvc.Models.JosModels;

namespace RandomizerMVC.Controllers
{
    public class JosMvcController : Controller
    {
        private readonly HttpClient _httpClient;

        public readonly int port = 5210;

        public JosMvcController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RandomPasswordOnePara()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RandomPasswordOnePara(RandomPasswordModel.OneParameter model)
        {
            if (ModelState.IsValid)
            {
                int length = model.UserPasswordLength;
                var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomPassword/OnePara?length={length}");
                response.EnsureSuccessStatusCode();
                var password = await response.Content.ReadAsStringAsync();

                ViewBag.RandomPassword = password;

            }

            return View(model);
        }
        [HttpGet]
        public IActionResult RandomPasswordFourPara()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RandomPasswordFourPara(RandomPasswordModel.FourParameter model)
        {
            if (ModelState.IsValid)
            {
                byte uppercaseAmount = model.uppercaseAmount;
                byte lowerCaseAmount = model.lowerCaseAmount;
                byte numbersAmount = model.numbersAmount;
                byte specialCharsAmount = model.specialCharsAmount;
                //  'https://localhost:7116/api/RandomPassword/FourPara?useUpperCase=2&useLowerCase=2&useNumbers=2&useSpecialCharacters=2' 
                var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomPassword/FourPara?useUpperCase={uppercaseAmount}&useLowerCase={lowerCaseAmount}&useNumbers={numbersAmount}&useSpecialCharacters={specialCharsAmount}");
                response.EnsureSuccessStatusCode();
                var password = await response.Content.ReadAsStringAsync();
                ViewBag.RandomPassword = password;

            }

            return View(model);
        }
        [HttpGet]
        public  IActionResult RandomPasswordFivePara()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RandomPasswordFivePara(RandomPasswordModel.FiveParameter model)
        {
            if (ModelState.IsValid)
            {
                int length = model.UserPasswordLength;
                bool useUpperCase = model.UserAllowUppercase;
                bool useLowerCase = model.UserAllowLowercase;
                bool useNumbers = model.UserAllowNumbers;
                bool useSpecialCharacters = model.UserAllowSpecialCharacters;
                var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomPassword/FivePara?length={length}&useUpperCase={useUpperCase}&useLowerCase={useLowerCase}&useNumbers={useNumbers}&useSpecialCharacters={useSpecialCharacters}");
                response.EnsureSuccessStatusCode();
                var password = await response.Content.ReadAsStringAsync();
                ViewBag.RandomPassword = password;

            }

            return View(model);
        }
        public async Task<IActionResult> RandomTime()
        {
            var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomTime/Time");

            string time = await response.Content.ReadAsStringAsync();

            ViewBag.RandomTime = time;
            return View();
        }
        public async Task<IActionResult> RandomLocation()
        {
            var response = await _httpClient.GetAsync($"http://localhost:{port}/api/RandomLocation/RandomLocation");

            string location = await response.Content.ReadAsStringAsync();

            ViewBag.RandomLocation = location;
            return View();
        }


    }
}
