using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherStation.Data;

namespace WeatherStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private Data.WeatherStation myStation;

        public WeatherController()
        {
            myStation = Data.WeatherStation.GetInstance();
        } // GET: api/Weather
        [HttpGet]
        public ActionResult<List<Weather>> Get()
        {
            return myStation.weather;
        }
        
        [HttpGet("{date}", Name = "GetByDate")]
      public ActionResult<List<Weather>> get(string date)
      {
          List<Weather> byDate = new List<Weather>();
          if (string.Compare(date, "-1") == 0)
          {
              byDate.Add(myStation.getLatest());
              return byDate;
          }
          byDate = myStation.GetWeather(date);
          return byDate;
      }

      // POST: api/Weather
        [HttpPost]
        public ActionResult<Weather> Post(Weather weather)
        {
            if (weather == null)
            {
                return BadRequest();
            }

            var newWeather = myStation.AddMeasurement(new Weather
            {
                date = DateTime.Now.ToShortDateString().ToString(),
                clock = DateTime.Now.ToShortTimeString().ToString(),
                Temperatur = weather.Temperatur,
                Humidity = weather.Humidity,
                AirPressure = weather.AirPressure
            });
            return CreatedAtAction("Get", new { id = newWeather.id, newWeather });
        }

    }
}
