using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chloe;
using Chloe.MySql;
using home.api.Model;
using home.dbhelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace home.api.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpPost]
        public List<DB_home_test> Post()
        {
            string connString = dbhelper.DBConfig.HomeMysqlConn;
            MySqlContext context = new MySqlContext(new MySqlConnectionFactory(connString).CreateConnection);

            IQuery<DB_home_test> q = context.Query<DB_home_test>();

            List<DB_home_test> dbhts =  q.Where(a => a.no != 4).ToList();
            
            return dbhts;
        }



    }


}
