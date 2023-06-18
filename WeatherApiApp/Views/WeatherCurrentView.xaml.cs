using WeatherApiApp.Services;
using WeatherApiApp.Services.Interfaces;

namespace WeatherApiApp.Views;

public partial class WeatherCurrentView : ContentView
{
	public WeatherCurrentView()
	{
		var viewModel = new WeatherApiApp.ViewModel.TommorowIO.WeatherCurrentTIO_VM();
		IGetWeatherDataSvc _currentWeatherService = Factory.GetCurrentWeatherService;
		viewModel.WeatherData = _currentWeatherService.GetWeatherCurrentAsync().Result;
		InitializeComponent();
		BindingContext = viewModel;

	}
}
