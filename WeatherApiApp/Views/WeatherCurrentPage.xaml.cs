using WeatherApiApp.Services.Interfaces;
using WeatherApiApp.Services;

namespace WeatherApiApp.Views;

public partial class WeatherCurrentPage : ContentPage
{
	public WeatherCurrentPage()
	{
		var viewModel = new WeatherApiApp.ViewModel.TommorowIO.WeatherCurrentTIO_VM(Factory.CreateCurrentWeatherService);
		InitializeComponent();
		BindingContext = viewModel;
	}
}