using System.Text.Json;
using CSharpWeatherForecastProject.Models;
using CSharpWeatherForecastProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharpWeatherForecastProject.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherService _weatherService;

        // Türkçe şehir isimlerini API'ye uygun isimlere dönüştüren dictionary
        private static readonly Dictionary<string, string> CityMappings = new Dictionary<string, string>
    {
        { "İstanbul", "Istanbul" },
        { "Ankara", "Ankara" },
        { "İzmir", "Izmir" },
        { "Londra", "London" },
        { "New York", "New York" },
        { "Paris", "Paris" },
        { "Tokyo", "Tokyo" }
    };

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                ViewBag.Message = "Lütfen bir şehir giriniz.";
                return View("Index");
            }

            // Türkçe şehir adını API'ye uygun hale getirmek için dictionary'i kullanıyoruz
            var apiCityName = CityMappings.ContainsKey(city) ? CityMappings[city] : city;

            var jsonResponse = await _weatherService.GetWeatherForecastAsync(apiCityName);

            Console.WriteLine(jsonResponse);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var weatherModel = JsonSerializer.Deserialize<WeatherModel>(jsonResponse, options);


            return View(weatherModel);
        }
    }
}
