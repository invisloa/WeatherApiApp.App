using WeatherApiApp.Services.Interfaces;
using WeatherApiApp.Services;

namespace WeatherApiApp.Views;

public partial class WeatherCurrentPage : ContentPage
{
	public WeatherCurrentPage()
	{
			var viewModel = Factory.CreateCurrentWeatherViewModel;
			BindingContext = viewModel;
			InitializeComponent();

	}
}