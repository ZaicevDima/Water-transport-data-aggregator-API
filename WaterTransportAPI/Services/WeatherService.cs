using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WaterTransportAPI.Services
{
    public class WeatherService
    {
        private WeatherConfigs? configs; 

        public WeatherService()
        {
            var configFileText = File.ReadAllText("./Config/config.json");
            var configFileJson = JObject.Parse(configFileText)?["Weather"];

            configs = configFileJson?.ToObject<WeatherConfigs>();
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

                ParseCharacteristics(weatherConditions, config.Schema, content);
            }

            return weatherConditions;
        }

        private Dictionary<string, string> GetWeatherCondDict()
        {
            var weatherCond = new Dictionary<string, string>();
            var chars = configs?.Chars.Split(',').ToList();

            if (chars == null)
            {
                return weatherCond;
            }

            foreach (var charact in chars)
            {
                weatherCond.Add(charact, "");
            }

            return weatherCond;
        }

        private void ParseCharacteristics(Dictionary<string, string> weatherConditions, 
            List<WeatherConfigs.Config.Characteristic> schema,
            string content)
        {
            var contentJson = JObject.Parse(content);

            foreach (var characteristic in schema)
            {
                var path = characteristic.TpChar.Split('/').ToList();
                var tag = contentJson[path[0]];

                for (var i = 1; i < path.Count; i++)
                {
                    if (tag == null)
                    {
                        break;
                    }

                    tag = tag[path[i]];
                }

                if (tag != null)
                {
                    weatherConditions[characteristic.SystemChar] = tag.ToString();
                }
            }

            return;
        }
    }
}
