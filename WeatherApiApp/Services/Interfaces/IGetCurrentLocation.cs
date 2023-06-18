using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.Services.Interfaces
{
	public interface IGetCurrentLocation
	{
		public Task<Location> GetCurrentLocationAsync();
	}
}
