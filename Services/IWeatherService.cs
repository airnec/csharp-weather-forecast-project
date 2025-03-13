namespace CSharpWeatherForecastProject.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherForecastAsync(string sehir);
    }
}