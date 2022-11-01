using Microsoft.AspNetCore.Mvc;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace WebApplication1.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
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

        [HttpPost(Name = "createbucket")]
        public string createbucket()
        {
            CreateBucket();
            return "success";

        }

        private Bucket CreateBucket(string projectId = "sonorous-zone-286119", string bucketName = "saon_test_new")
        {
            var storage = StorageClient.Create();
            var bucket = storage.CreateBucket(projectId, bucketName);
            //Console.WriteLine($"Created {bucketName}.");
            return bucket;
        }
    }
}