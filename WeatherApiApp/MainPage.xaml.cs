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
		/*		count++;

				if (count == 1)
					CounterBtn.Text = $"Clicked {count} time";
				else
					CounterBtn.Text = $"Clicked {count} times";

				SemanticScreenReader.Announce(CounterBtn.Text);
		*/
		await SendRequestAsync(new Uri("https://api.tomorrow.io/v4/weather/realtime?location=toronto&apikey=Cj66O8OLTih8hPqA7AOKfevJuX11N1hp"));
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

