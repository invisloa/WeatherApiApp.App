using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.Model.WeatherModels
{
	public interface IWeatherCurrentViewModel
	{
		WeatherProperty LocationName { get; }
		WeatherProperty Time { get; }
		WeatherProperty Temperature { get; }
		WeatherProperty TemperatureApparent { get; }
		WeatherProperty WeatherCode { get; }
		WeatherProperty PrecipitationProbability { get; }
		WeatherProperty RainIntensity { get; }
		WeatherProperty SleetIntensity { get; }
		WeatherProperty SnowIntensity { get; }
		WeatherProperty FreezingRainIntensity { get; }
		WeatherProperty WindSpeed { get; }
		WeatherProperty PressureSurfaceLevel { get; }
	}
}
