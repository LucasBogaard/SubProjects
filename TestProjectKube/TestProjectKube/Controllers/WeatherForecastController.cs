using Microsoft.AspNetCore.Mvc;

namespace TestProjectKube.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("WeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Load")]
        public double GetLoad()
        {
            // Adjust the loop iterations based on your desired CPU load
            int iterations = 1000000000;
            double total = 0;
            // Perform a simple calculation in a loop
            for (int i = 0; i < iterations; i++)
            {
                // You can replace this with any computation you want to simulate CPU load
                double result = Math.Sqrt(i);
                total = total + result;
            }
            return total;
        }


    }
}
