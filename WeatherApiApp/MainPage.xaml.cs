using WeatherApiApp.Services.WeatherServices;

namespace WeatherApiApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		Console.WriteLine("Hello, World!");

	}
	static async Task SendRequestAsync(Uri uri)
	{
		HttpResponseMessage response;
		using (HttpClient client = new HttpClient())
		{
			response = await client.GetAsync(uri);
		}
	}
}

