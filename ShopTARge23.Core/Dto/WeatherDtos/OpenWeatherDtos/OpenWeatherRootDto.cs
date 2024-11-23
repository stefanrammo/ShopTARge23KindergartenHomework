using System.Text.Json.Serialization;

namespace ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos
{
    public class OpenWeatherRootDto
    {
        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("main")]
        public string Main { get; set; }
    }
}
