using WeatherApiApp.Services.Interfaces;
using WeatherApiApp.Services;

namespace WeatherApiApp.Views;

public partial class WeatherCurrentPage : ContentPage
{
	public WeatherCurrentPage()
	{
		var viewModel = new WeatherApiApp.ViewModel.TommorowIO.WeatherCurrentTIO_VM();
		IGetWeatherDataSvc _currentWeatherService = Factory.GetCurrentWeatherService;
		viewModel.WeatherData = _currentWeatherService.GetWeatherCurrentAsync().Result;
		InitializeComponent();
		BindingContext = viewModel;
	}
}