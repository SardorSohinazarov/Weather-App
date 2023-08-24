using Newtonsoft.Json;
using System.Diagnostics;
using Weather.Model;

namespace Weather;

public class RestService
{
    HttpClient _client;

    public RestService()
    {
        _client = new HttpClient();
    }

    public async Task<WeatherDate> GetWeatherDate(string query)
    {
        WeatherDate weatherDate = null;

        try
        {
            var response = await _client.GetAsync(query);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherDate = JsonConvert.DeserializeObject<WeatherDate>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
        return weatherDate;
    }
}
