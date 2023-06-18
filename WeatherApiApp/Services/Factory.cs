using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.TommorowIO;
using WeatherApiApp.Model.WeatherModels;
using WeatherApiApp.Services.Interfaces;
using WeatherApiApp.Services.WeatherServices;

namespace WeatherApiApp.Services
{
	public static class Factory
	{
		public static IGetWeatherDataSvc CreateGetWeatherData => new WeatherServiceTommorowIO();
		public static IWeatherCurrentModel CreateWeatherCurrentDataModel => new WeatherModelTommorowIOCurrent();

		public static IGetWeatherDataSvc GetCurrentWeatherService => new WeatherServiceTommorowIO();
	}
}
