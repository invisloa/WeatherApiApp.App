using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApiApp.Model;
using WeatherApiApp.Model.WeatherModels;
using WeatherApiApp.Services;
using WeatherApiApp.Services.Interfaces;

namespace WeatherApiApp.ViewModel.TommorowIO
{
	public class WeatherCurrentTIO_VM : BaseWeatherViewModel, IWeatherCurrentViewModel
	{
		private WeatherProperty location;
		private DateTime _lastUpdatedTime;


		public ICommand GetCurrentWeatherCommand { get; }
		public IWeatherCurrentModel WeatherData
		{
			get => _weatherDataModel;
			set
			{
				if (_weatherDataModel != value)
				{
					_weatherDataModel = value;
					OnPropertyChanged();
				}
			}
		}
		#region Primary Data
		public WeatherProperty LocationName { get => WeatherData.LocationName; set { } }
		public WeatherProperty Time { get => WeatherData.Time; set { } }
		public WeatherProperty Temperature { get => WeatherData.Temperature; set { } }
		public WeatherProperty TemperatureApparent { get => WeatherData.TemperatureApparent; set { } }
		public WeatherProperty WeatherCode { get => WeatherData.WeatherCode; set { } }
		public WeatherProperty PrecipitationProbability { get => WeatherData.PrecipitationProbability; set { } }
		public WeatherProperty RainIntensity { get => WeatherData.RainIntensity; set { } }
		public WeatherProperty SleetIntensity { get => WeatherData.SleetIntensity; set { } }
		public WeatherProperty SnowIntensity { get => WeatherData.SnowIntensity; set { } }
		public WeatherProperty FreezingRainIntensity { get => WeatherData.FreezingRainIntensity; set { } }
		public WeatherProperty WindSpeed { get => WeatherData.WindSpeed; set { } }
		public WeatherProperty PressureSurfaceLevel { get => WeatherData.PressureSurfaceLevel; set { } }
		#endregion


		public ObservableCollection<string> SomeList { get; set; }

		public WeatherCurrentTIO_VM(IGetWeatherDataSvc _currentWeatherService)
		{
			WeatherData = _currentWeatherService.GetWeatherCurrentAsync().Result;
			_dataService = _currentWeatherService;
			GetCurrentWeatherCommand = new RelayCommand(GetCurrentWeather);
		}

		private async void GetCurrentWeather()
		{
			if (WeatherData == null || DateTime.Now - _lastUpdatedTime > TimeSpan.FromMinutes(10))
			{
				WeatherData = await _dataService.GetWeatherCurrentAsync();
				setProperties();
			}
		}
		private void setProperties()
		{
			Time.Value = WeatherData.Time.Value;
			Temperature.Value = WeatherData.Temperature.Value;
			TemperatureApparent.Value = WeatherData.TemperatureApparent.Value;
			WeatherCode.Value = WeatherData.WeatherCode.Value;
			PrecipitationProbability.Value = WeatherData.PrecipitationProbability.Value;
			RainIntensity.Value = WeatherData.RainIntensity.Value;
			SleetIntensity.Value = WeatherData.SleetIntensity.Value;
			SnowIntensity.Value = WeatherData.SnowIntensity.Value;
			FreezingRainIntensity.Value = WeatherData.FreezingRainIntensity.Value;
			WindSpeed.Value = WeatherData.WindSpeed.Value;
			PressureSurfaceLevel.Value = WeatherData.PressureSurfaceLevel.Value;
		}
	}
}
