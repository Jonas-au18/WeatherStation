using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace WeatherStation.Data
{
    public class WeatherStation : ITemp
    {
        private static WeatherStation instance = null;
        private readonly Dictionary<long, Weather> measurements;

        private WeatherStation()
        {
            measurements = new Dictionary<long, Weather>();
            new List<Weather>
            {
                new Weather
                {
                    date = DateTime.Now.ToShortDateString().ToString(),
                    clock = DateTime.Now.ToShortTimeString().ToString(), Temperatur = 30, AirPressure = 20,
                    Humidity = 40
                },
                new Weather
                {
                    date = DateTime.Now.ToShortDateString().ToString(),
                    clock = DateTime.Now.ToShortTimeString().ToString(), Temperatur = 25, AirPressure = 30,
                    Humidity = 20
                }
            }.ForEach(r => AddMeasurement(r));
        }

        static public WeatherStation GetInstance()
        {
            if (instance == null)
                instance = new WeatherStation();
            return instance;
        }

        public List<Weather> GetWeather(string date)
        {
            List<Weather> dateList = new List<Weather>();
            long index = 0;
            foreach (var i in measurements)
            {
                if (string.Compare(date, i.Value.date.ToString()) == 0)
                {
                    index = i.Value.id;
                    dateList.Add(measurements[index]);
                }
            }

            return dateList;
        }

        public Weather getLatest()
        {
            long index = measurements.Count - 1;
            return measurements[index];
        }

        public Weather this[long id] => measurements.ContainsKey(id) ? measurements[id] : null;

        public List<Weather> weather => measurements.Values.ToList();

        public Weather AddMeasurement([FromBody]Weather weather)
        {
            if (weather.id == 0)
            {
                int key = measurements.Count;
                while (measurements.ContainsKey(key))
                {
                    key++;
                }

                weather.id = key;
            }

            measurements[weather.id] = weather;
            return weather;
        }

    }
}