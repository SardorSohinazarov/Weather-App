using Weather.Model;

namespace Weather;


public partial class MainPage : ContentPage
{
    RestService _restService;

    public MainPage()
    {
        InitializeComponent();

        _restService = new RestService();
    }

    async void OnGetWeatherButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
        {
            WeatherDate weatherDate = await _restService.GetWeatherDate(GenerateRequestURL(Constants.OpenWeatherMapEndpoint));

            BindingContext = weatherDate;
        }
    }

    string GenerateRequestURL(string endPoint)
    {
        string requestUri = endPoint;

        requestUri += $"?q={_cityEntry.Text}";
        requestUri += $"&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
        return requestUri;
    }
}

