using WaterTransportAPI.Models;

namespace WaterTransportAPI.Services
{
    public class WeatherService
    {
        public async Task<String> GetWeatherConditionsAsync(double lat, double lon)
        {
            var weatherConditions = new Weather();

            String resultJSON = "";

            var url = "https://api.weather.yandex.ru/v2/informers?lat=" + lat.ToString() +"&lon=" + lon.ToString();
            Console.WriteLine(url);
            using var client = new HttpClient();

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("X-Yandex-API-Key", "2fc0daec-8f35-471a-b83f-a22d956e1697");
            var res = await client.SendAsync(msg);
            var content = await res.Content.ReadAsStringAsync();


            return content;
        }
    }
}
