using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.TommorowIO;
using WeatherApiApp.Model.WeatherModels;
using WeatherApiApp.Services.Interfaces;
using WeatherApiApp.Services.WeatherServices;
using WeatherApiApp.ViewModel.TommorowIO;

namespace WeatherApiApp.Services
{
	public static class Factory
	{
		public static IGetWeatherDataSvc CreateGetWeatherData => new WeatherServiceTommorowIO();
		public static IWeatherCurrentModel CreateWeatherCurrentDataModel => new WeatherModelTommorowIOCurrent();

		public static IGetWeatherDataSvc CreateCurrentWeatherService => new WeatherServiceTommorowIO();
		public static IWeatherCurrentModel CreateWeatherModelTommorowIOCurrent { get => new WeatherModelTommorowIOCurrent(); }
		public static IWeatherCurrentViewModel CreateCurrentWeatherViewModel { get => new WeatherCurrentTIO_VM(Factory.CreateCurrentWeatherService); }
	}
}
