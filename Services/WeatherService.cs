
namespace CSharpWeatherForecastProject.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherAPI:ApiKey"];  // appsettings.json'dan API anahtarını alıyoruz
        }

        public async Task<string> GetWeatherForecastAsync(string sehir)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={sehir}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }
}
