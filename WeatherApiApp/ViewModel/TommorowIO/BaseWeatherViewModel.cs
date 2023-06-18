using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.WeatherModels;
using WeatherApiApp.Services;
using WeatherApiApp.Services.Interfaces;

namespace WeatherApiApp.ViewModel.TommorowIO
{
	public abstract class BaseWeatherViewModel : BaseViewModel
	{

		protected Dictionary<string, string> _weatherProperties = new Dictionary<string, string>();
		protected IWeatherCurrentModel _weatherDataModel;
		protected IGetWeatherDataSvc _dataService = Factory.CreateGetWeatherData;
	}
}
