using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.TommorowIO;
using WeatherApiApp.Model.WeatherModels;
using WeatherApiApp.Services.Interfaces;

namespace WeatherApiApp.Services.WeatherServices
{
	public class WeatherServiceTommorowIO : IGetWeatherDataSvc
	{
		private static readonly HttpClient client = new HttpClient();
		private const string _myApiKey = "Cj66O8OLTih8hPqA7AOKfevJuX11N1hp";
		private const string _location = "43.70,-79.42";
		IWeatherCurrentModel _weatherCurrentModel = Factory.CreateWeatherCurrentDataModel;
		
		private Uri CreateUri(string endpoint)
		{
			return new Uri($"https://api.tomorrow.io/v4/weather/{endpoint}?location={_location}&apikey={_myApiKey}");
		}
		static WeatherServiceTommorowIO()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}


		public Task<IWeatherCurrentModel> GetWeatherCurrentAsync()
		{
			return SendRequestAsync(CreateUri("realtime"));
		}

		private async Task<IWeatherCurrentModel> SendRequestAsync(Uri uri)
		{
			HttpResponseMessage response;
			try
			{
				response = await client.GetAsync(uri).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw;
			}
			if(!response.IsSuccessStatusCode)
			{
				throw new Exception($"Error: {response.StatusCode}");
			}

			string responseBody = await response.Content.ReadAsStringAsync();
			try
			{ 
			_weatherCurrentModel = JsonConvert.DeserializeObject<WeatherModelTommorowIOCurrent>(responseBody);  // DESERIALIZE TO A CONCRETE OBJECT TODO CONVERTER IF NEEDED LATER

			return _weatherCurrentModel;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw;
			}
		}
	}
}
