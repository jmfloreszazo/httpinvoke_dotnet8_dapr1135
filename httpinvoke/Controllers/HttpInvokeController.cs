using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace httpinvoke.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HttpInvokeController : ControllerBase
    {
     
        private readonly ILogger<HttpInvokeController> _logger;

        public HttpInvokeController(ILogger<HttpInvokeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api1", Name = "GetWeatherForecastApi1")]
        public async Task<string> GetWeatherForecastApi1()
        {
            var httpClient = DaprClient.CreateInvokeHttpClient("weatherforecastapi");
            var response = await httpClient.GetAsync("/WeatherForecast");
            return await response.Content.ReadAsStringAsync();
        }

        [HttpGet("api2", Name = "GetWeatherForecastApi2")]
        public async Task<string> GetWeatherForecastApi2()
        {
            var httpClient = DaprClient.CreateInvokeHttpClient("weatherforecastapi2");
            var response = await httpClient.GetAsync("/WeatherForecast");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
