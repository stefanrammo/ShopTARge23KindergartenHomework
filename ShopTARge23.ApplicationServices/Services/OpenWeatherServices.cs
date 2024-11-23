using Nancy.Json;
using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using System.Net;

namespace ShopTARge23.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherRootDto> OpenWeatherResult(OpenWeatherRootDto dto)
        {
            string owmApiKey = "42d59e5dad13543ec957ab68ba4115d6";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.Name}&appid={owmApiKey}&units=metric";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    Console.WriteLine("API Response: " + json); 

                    OpenWeatherRootDto openWeatherResult = new JavaScriptSerializer().Deserialize<OpenWeatherRootDto>(json);


                    dto.Name = openWeatherResult.Name;  
                    dto.Main = openWeatherResult.Main; 
                    dto.Wind = openWeatherResult.Wind;  
                    dto.Weather = openWeatherResult.Weather;  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
                throw;
            }

            return dto;
        }
    }
}
