using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherApiApp.Model.WeatherModels;

namespace WeatherApiApp.Model.TommorowIO
{
	public abstract class WeatherModelTommorowIOBase : IWeatherCurrentModel
	{


		public class Location
		{
			public double lat { get; set; }
			public double lon { get; set; }
			public string name { get; set; }
			public string type { get; set; }
		}



/*		public virtual WeatherProperty ErrorCode { get; set; }
		public virtual WeatherProperty ErrorType { get; set; }
		public virtual WeatherProperty ErrorMessage { get; set; }
*/		public virtual WeatherProperty LocationGPS { get; set; }
		public virtual WeatherProperty LocationName { get; set; }
		public virtual WeatherProperty Time { get; set; }
		public virtual WeatherProperty Temperature { get; set; }
		public virtual WeatherProperty TemperatureApparent { get; set; }
		public virtual WeatherProperty WeatherCode { get; set; }
		public virtual WeatherProperty PrecipitationProbability { get; set; }
		public virtual WeatherProperty RainIntensity { get; set; }
		public virtual WeatherProperty SleetIntensity { get; set; }
		public virtual WeatherProperty SnowIntensity { get; set; }
		public virtual WeatherProperty FreezingRainIntensity { get; set; }
		public virtual WeatherProperty WindSpeed { get; set; }
		public virtual WeatherProperty PressureSurfaceLevel { get; set; }

		#region Weather Codes
		/*	  
			  "weatherCode": {
			  "0": "Unknown",
			  "1000": "Clear, Sunny",
			  "1100": "Mostly Clear",
			  "1101": "Partly Cloudy",
			  "1102": "Mostly Cloudy",
			  "1001": "Cloudy",
			  "2000": "Fog",
			  "2100": "Light Fog",
			  "4000": "Drizzle",
			  "4001": "Rain",
			  "4200": "Light Rain",
			  "4201": "Heavy Rain",
			  "5000": "Snow",
			  "5001": "Flurries",
			  "5100": "Light Snow",
			  "5101": "Heavy Snow",
			  "6000": "Freezing Drizzle",
			  "6001": "Freezing Rain",
			  "6200": "Light Freezing Rain",
			  "6201": "Heavy Freezing Rain",
			  "7000": "Ice Pellets",
			  "7101": "Heavy Ice Pellets",
			  "7102": "Light Ice Pellets",
			  "8000": "Thunderstorm"
			},
		*/
		#endregion

	}
}
