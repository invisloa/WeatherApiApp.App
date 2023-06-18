using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.Model.WeatherModels
{
	public interface IWeatherCurrentModel
	{
		public WeatherProperty LocationGPS { get; set; }
		public WeatherProperty LocationName { get; set; }
		public WeatherProperty Time { get; set; }
		public WeatherProperty Temperature { get; set; }
		public WeatherProperty TemperatureApparent { get; set; }
		public WeatherProperty WeatherCode { get; set; }
		public WeatherProperty PrecipitationProbability { get; set; }
		public WeatherProperty RainIntensity { get; set; }
		public WeatherProperty SleetIntensity { get; set; }
		public WeatherProperty SnowIntensity { get; set; }
		public WeatherProperty FreezingRainIntensity { get; set; }
		public WeatherProperty WindSpeed { get; set; }
		public WeatherProperty PressureSurfaceLevel { get; set; }

	}
}
