using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace TranslateApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ForecastController> _logger;

        public ForecastController(ILogger<ForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetForecast")]
        public String Get(int id)
        {
            //IEnumerable<Forecast>
            return "100";
                /*Enumerable.Range(1, 5).Select(index => new Forecast
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
       
    }
}