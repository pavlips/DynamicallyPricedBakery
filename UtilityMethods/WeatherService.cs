using Newtonsoft.Json.Linq;


public class WeatherService
{
    private readonly HttpClient httpClient;
    private readonly string apiKey = "1808985d13b1ce6b9b5a5916e461a41c";
    private readonly double latitude = 52.1951;
    private readonly double longitude = 0.1313;

    public WeatherService()
    {
        httpClient = new HttpClient();
    }

    public async Task<double> GetWeatherBasedPriceMultiplier()
    {
        //PARAMETERISED WEB CALL TO API
        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}";
        string response = await httpClient.GetStringAsync(url);

        // PARSING JSON
        JObject jsonResponse = JObject.Parse(response);
        string mainCondition = jsonResponse["weather"][0]["main"].ToString();


        switch (mainCondition)
        {
            case "Clear":
                return 1.5;
            case "Clouds":
                return 1.0;
            case "Rain":
                return 0.8;
            default:
                return 1.0;
        }
    }
}
