using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.WeatherModels;

namespace WeatherApiApp.Services.Interfaces
{
	public interface IGetWeatherDataSvc
	{
		public Task<IWeatherCurrentModel> GetWeatherCurrentAsync();
	}
}
