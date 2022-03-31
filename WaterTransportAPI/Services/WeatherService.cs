using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WaterTransportAPI.Services
{
    public class WeatherService
    {
        private ApiConfigs? configs; 

        public WeatherService()
        {
            var jsonConfig = File.ReadAllText("./Config/config.json");
            configs = JsonConvert.DeserializeObject<ApiConfigs>(jsonConfig);
        }

        public async Task<Dictionary<string, string>> GetWeatherConditionsAsync(double lat, double lon)
        {
            var weatherConditions = GetWeatherCondDict();

            if (configs == null)
            {
                return weatherConditions;
            }

            foreach (var config in configs.ListConfigs)
            {
                var url = config.Url + 
                    "lat=" + lat.ToString("0.00000", CultureInfo.InvariantCulture) + 
                    "&lon=" + lon.ToString("0.00000", CultureInfo.InvariantCulture);
                using var client = new HttpClient();

                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.Add(config.KeyName, config.KeyValue);

                var res = await client.SendAsync(msg);
                var content = await res.Content.ReadAsStringAsync();

                weatherConditions = ParseCharacteristics(weatherConditions, config.Schema, content);
            }

            return weatherConditions;
        }

        private Dictionary<string, string> GetWeatherCondDict()
        {
            var weatherCond = new Dictionary<string, string>();
            var chars = configs?.Chars.Split(',').ToList();

            foreach (var charact in chars)
            {
                weatherCond.Add(charact, "");
            }

            return weatherCond;
        }

        private Dictionary<string, string> ParseCharacteristics(Dictionary<string, string> weatherConditions, 
            List<ApiConfigs.Config.Characteristic> schema,
            string content)
        {
            var data = JObject.Parse(content);

            foreach (var characteristic in schema)
            {
                Console.WriteLine(characteristic.SystemChar + " " + characteristic.TpChar);

                var path = characteristic.TpChar.Split('/').ToList();
                var tag = data[path[0]];
                for (var i = 1; i < path.Count; i++)
                {
                    tag = tag[path[i]];
                }

                weatherConditions[characteristic.SystemChar] = (string)tag;

            }

            return weatherConditions;
        }
    }
}
