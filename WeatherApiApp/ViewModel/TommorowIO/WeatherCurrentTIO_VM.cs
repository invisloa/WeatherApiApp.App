using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model;
using WeatherApiApp.Model.TommorowIO;

namespace WeatherApiApp.ViewModel.TommorowIO
{
	public class WeatherModelTommorowIOCurrent : WeatherModelTommorowIOBase
	{
		#region Interface Properties
		private WeatherProperty _temperature;
		public override WeatherProperty Temperature
		{
			get
			{
				return _temperature ?? (_temperature = new WeatherProperty("Temperature", data.values.temperature.ToString()));
			}
			set
			{
				if (double.TryParse(value.Value, out double temperatureValue))
				{
					data.values.temperature = temperatureValue;
					_temperature = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid temperature value.");
				}
			}
		}
		private WeatherProperty _weatherCode;
		public override WeatherProperty WeatherCode
		{
			get
			{
				return _weatherCode ?? (_weatherCode = new WeatherProperty("WeatherCode", data.values.weatherCode.ToString()));
			}
			set
			{
				if (int.TryParse(value.Value, out int weatherCodeValue))
				{
					data.values.weatherCode = weatherCodeValue;
					_weatherCode = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid weather code value.");
				}
			}
		}

		private WeatherProperty _precipitationProbability;
		public override WeatherProperty PrecipitationProbability
		{
			get
			{
				return _precipitationProbability ?? (_precipitationProbability = new WeatherProperty("PrecipitationProbability", data.values.precipitationProbability.ToString()));
			}
			set
			{
				if (int.TryParse(value.Value, out int precipitationProbabilityValue))
				{
					data.values.precipitationProbability = precipitationProbabilityValue;
					_precipitationProbability = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid precipitation probability value.");
				}
			}
		}
		private WeatherProperty _locationGPS;
		public override WeatherProperty LocationGPS
		{
			get
			{
				return _locationGPS ?? (_locationGPS = new WeatherProperty("LocationGPS", $"{location.Latitude},{location.Longitude}"));
			}
			set
			{
				string[] latAndLon = value.Value.Split(',');
				if (latAndLon.Length == 2 &&
					double.TryParse(latAndLon[0], out double latValue) &&
					double.TryParse(latAndLon[1], out double lonValue))
				{
					location.Latitude = latValue;
					location.Longitude = lonValue;
					_locationGPS = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid GPS location value.");
				}
			}
		}
		private WeatherProperty _locationName;
		public override WeatherProperty LocationName
		{
			get
			{
				return _locationName ?? (_locationName = new WeatherProperty("LocationName", location.LocationName));
			}
			set
			{
				if (!string.IsNullOrEmpty(value.Value))
				{
					location.LocationName = value.Value;
					_locationName = value;
				}
				else
				{
					// Handle the case when the value is null or empty
					throw new ArgumentException("Invalid location name value.");
				}
			}
		}
		private WeatherProperty _time;
		public override WeatherProperty Time
		{
			get
			{
				return _time ?? (_time = new WeatherProperty("Time", data.time.ToString()));
			}
			set
			{
				if (DateTime.TryParse(value.Value, out DateTime timeValue))
				{
					data.time = timeValue;
					_time = value;
				}
				else
				{
					throw new ArgumentException("Invalid time value.");
				}
			}
		}
		private WeatherProperty _temperatureApparent;
		public override WeatherProperty TemperatureApparent
		{
			get
			{
				return _temperatureApparent ?? (_temperatureApparent = new WeatherProperty("TemperatureApparent", data.values.temperatureApparent.ToString()));
			}
			set
			{
				if (double.TryParse(value.Value, out double temperatureApparentValue))
				{
					data.values.temperatureApparent = temperatureApparentValue;
					_temperatureApparent = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid TemperatureApparent value.");
				}
			}
		}
		private WeatherProperty _rainIntensity;
		public override WeatherProperty RainIntensity
		{
			get
			{
				return _rainIntensity ?? (_precipitationProbability = new WeatherProperty("RainIntensity", data.values.rainIntensity.ToString()));
			}
			set
			{
				if (int.TryParse(value.Value, out int rainIntensityValue))
				{
					data.values.rainIntensity = rainIntensityValue;
					_rainIntensity = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid rainIntensity probability value.");
				}
			}
		}
		private WeatherProperty _sleetIntensity;
		public override WeatherProperty SleetIntensity
		{
			get
			{
				return _sleetIntensity ?? (_sleetIntensity = new WeatherProperty("SleetIntensity", data.values.sleetIntensity.ToString()));
			}
			set
			{
				if (int.TryParse(value.Value, out int sleetIntensityValue))
				{
					data.values.sleetIntensity = sleetIntensityValue;
					_sleetIntensity = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid sleet intensity value.");
				}
			}
		}

		private WeatherProperty _snowIntensity;
		public override WeatherProperty SnowIntensity
		{
			get
			{
				return _snowIntensity ?? (_snowIntensity = new WeatherProperty("SnowIntensity", data.values.snowIntensity.ToString()));
			}
			set
			{
				if (int.TryParse(value.Value, out int snowIntensityValue))
				{
					data.values.snowIntensity = snowIntensityValue;
					_snowIntensity = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid snow intensity value.");
				}
			}
		}

		private WeatherProperty _freezingRainIntensity;
		public override WeatherProperty FreezingRainIntensity
		{
			get
			{
				return _freezingRainIntensity ?? (_freezingRainIntensity = new WeatherProperty("FreezingRainIntensity", data.values.freezingRainIntensity.ToString()));
			}
			set
			{
				if (int.TryParse(value.Value, out int freezingRainIntensityValue))
				{
					data.values.freezingRainIntensity = freezingRainIntensityValue;
					_freezingRainIntensity = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid freezing rain intensity value.");
				}
			}
		}

		private WeatherProperty _windSpeed;
		public override WeatherProperty WindSpeed
		{
			get
			{
				return _windSpeed ?? (_windSpeed = new WeatherProperty("WindSpeed", data.values.windSpeed.ToString()));
			}
			set
			{
				if (double.TryParse(value.Value, out double windSpeedValue))
				{
					data.values.windSpeed = windSpeedValue;
					_windSpeed = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid wind speed value.");
				}
			}
		}

		private WeatherProperty _pressureSurfaceLevel;
		public override WeatherProperty PressureSurfaceLevel
		{
			get
			{
				return _pressureSurfaceLevel ?? (_pressureSurfaceLevel = new WeatherProperty("PressureSurfaceLevel", data.values.pressureSurfaceLevel.ToString()));
			}
			set
			{
				if (double.TryParse(value.Value, out double pressureSurfaceLevelValue))
				{
					data.values.pressureSurfaceLevel = pressureSurfaceLevelValue;
					_pressureSurfaceLevel = value;
				}
				else
				{
					// Handle the case when parsing fails
					throw new ArgumentException("Invalid pressure surface level value.");
				}
			}
		}

		#endregion


		public Data data { get; set; }
		public LocationApi location { get; set; }
		public class Data
		{
			public DateTime time { get; set; }
			public Values values { get; set; }
		}
		public class Values
		{
			public double? cloudBase { get; set; }
			public double? cloudCeiling { get; set; }
			public int? cloudCover { get; set; }
			public double? dewPoint { get; set; }
			public int? freezingRainIntensity { get; set; }
			public int? humidity { get; set; }
			public int? precipitationProbability { get; set; }
			public double? pressureSurfaceLevel { get; set; }
			public int? rainIntensity { get; set; }
			public int? sleetIntensity { get; set; }
			public int? snowIntensity { get; set; }
			public double? temperature { get; set; }
			public double? temperatureApparent { get; set; }
			public int? uvHealthConcern { get; set; }
			public int? uvIndex { get; set; }   //0-2: Low	3-5: Moderate	6-7: High	8-10: Very High		11+: Extreme
			public double? visibility { get; set; }
			public int? weatherCode { get; set; }
			public double? windDirection { get; set; }
			public double? windGust { get; set; }
			public double? windSpeed { get; set; }
		}



	}
}
