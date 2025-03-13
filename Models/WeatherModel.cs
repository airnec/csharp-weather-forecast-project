using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpWeatherForecastProject.Models
{
    public class WeatherModel
    {
        [JsonPropertyName("name")]
        public string? City { get; set; }

        [JsonPropertyName("main")]
        public MainWeatherData? Main { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDescription>? Weather { get; set; }
    }

    public class MainWeatherData
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
