using System;

namespace WeatherStation
{
    public class WeatherDto
    {
        public string date
        {
            get { return date; }
            set { DateTime.Now.ToShortDateString().ToString(); }
        }
        public string clock
        {
            get { return clock; }
            set { DateTime.Now.ToShortTimeString().ToString(); }
        }

        public double Temperatur { get; set; }

        public int Humidity { get; set; }

        public int AirPressure { get; set; }
    
}
}