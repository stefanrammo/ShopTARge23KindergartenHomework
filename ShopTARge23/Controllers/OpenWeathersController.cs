using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.OpenWeathers;

namespace ShopTARge23.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeathersController
            (
                IOpenWeatherServices openWeatherServices
            )
        {
            _openWeatherServices = openWeatherServices;
        }

        public IActionResult Index(string? city)
        {
            ViewData["Title"] = "OpenWeather";

            OpenWeatherIndexViewModel vm = new OpenWeatherIndexViewModel();
            OpenWeatherSearchViewModel searchModel = new OpenWeatherSearchViewModel();  

            if (!string.IsNullOrWhiteSpace(city))
            {
                OpenWeatherRootDto dto = new OpenWeatherRootDto { Name = city };
                _openWeatherServices.OpenWeatherResult(dto);

                if (dto != null && dto.Main != null && dto.Weather != null && dto.Weather.Any())
                {
                    vm = new OpenWeatherIndexViewModel
                    {
                        Name = dto.Name,
                        Temp = dto.Main.Temp,
                        FeelsLike = dto.Main.FeelsLike,
                        Pressure = dto.Main.Pressure,
                        Humidity = dto.Main.Humidity,
                        WindSpeed = dto.Wind.Speed,
                        WeatherConditions = dto.Weather.Select(w => new WeatherCondition
                        {
                            Main = w.Main
                        }).ToList(),
                    };
                }
                else
                {
                    TempData["Error"] = "No data found for the specified city. Please check the name and try again.";
                }
            }

            return View(Tuple.Create(vm, searchModel));
        }




        [HttpPost]
        public IActionResult SearchCity(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", new { city = model.Name });
            }

            TempData["Error"] = "Invalid input. Please try again.";
            return RedirectToAction("Index");
        }
    }
}
