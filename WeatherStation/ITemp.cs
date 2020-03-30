using System.Collections.Generic;

namespace WeatherStation
{
    public interface ITemp
    {
        List<Weather> weather { get; }
        Weather this[long id] { get; }
        Weather AddMeasurement(Weather weather);
    }
}
