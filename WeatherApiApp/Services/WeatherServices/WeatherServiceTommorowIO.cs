using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.WeatherModels;
using WeatherApiApp.Services.Interfaces;

namespace WeatherApiApp.Services.WeatherServices
{
	public class WeatherServiceTommorowIO : IGetWeatherDataSvc
	{
		private static readonly HttpClient client = new HttpClient();
		private const string _myApiKey = "Cj66O8OLTih8hPqA7AOKfevJuX11N1hp";
		private const string _location = "43.70,-79.42";
		IWeatherCurrentModel weatherCurrentModel = Factory.CreateWeatherCurrentDataModel;

		static WeatherServiceTommorowIO()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}

		private Uri CreateUri(string endpoint)
		{
			return new Uri($"https://api.tomorrow.io/v4/weather/{endpoint}?location={_location}&apikey={_myApiKey}");
		}
		static async Task SendRequestAsync(Uri uri)
		{
			HttpResponseMessage response;
			using (HttpClient client = new HttpClient())
			{
				response = await client.GetAsync(uri);
			}
		}

		private async Task<IWeatherCurrentModel> SendRequestAsync<T>(Uri uri)
		{
			HttpResponseMessage response;
			await SendRequestAsync(new Uri("https://api.tomorrow.io/v4/weather/realtime?location=toronto&apikey=Cj66O8OLTih8hPqA7AOKfevJuX11N1hp"));
			try
			{
				response = await client.GetAsync("https://api.tomorrow.io/v4/weather/realtime?location=toronto&apikey=Cj66O8OLTih8hPqA7AOKfevJuX11N1hp");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw;
			}

			if (!response.IsSuccessStatusCode)
			{
				throw new Exception($"Error: {response.StatusCode}");
			}

			string responseBody = await response.Content.ReadAsStringAsync();
			try
			{
				weatherCurrentModel = JsonConvert.DeserializeObject<IWeatherCurrentModel>(responseBody);
				return weatherCurrentModel;
			}
			catch (Exception ex) { await Console.Out.WriteLineAsync($"{ex}"); }
			return null;
		}

		public Task<IWeatherCurrentModel> GetWeatherCurrentAsync()
		{
			return SendRequestAsync<IWeatherCurrentModel>(CreateUri("realtime"));
		}
	}
}
