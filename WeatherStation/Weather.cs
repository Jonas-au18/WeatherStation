using System;

namespace WeatherStation
{
    public class Weather
    {
        public Weather()
        {
            id = 0;
            date = DateTime.Now.ToShortDateString().ToString();
            clock = DateTime.Now.ToShortTimeString().ToString();
        }
        public long id;
        public string date { get; set; }

        public string clock { get; set; }
        
        public double Temperatur { get; set; }

        public int Humidity { get; set; }

        public int AirPressure { get; set; }


    }
}