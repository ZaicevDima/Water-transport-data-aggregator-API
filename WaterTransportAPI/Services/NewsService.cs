using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Text;

namespace WaterTransportAPI.Services
{
    public class NewsService
    {
        //private WeatherConfigs? configs; 

        public NewsService()
        {
            //var configFileText = File.ReadAllText("./Config/config.json");
            //var configFileJson = JObject.Parse(configFileText)?["Weather"];

            //configs = configFileJson?.ToObject<WeatherConfigs>();
        }

        public async Task<string> GetNewsAsync(string searchQuery)
        {
            ServicePointManager.Expect100Continue = false;

            /* Адрес для совершения запроса, полученный при регистрации IP,
            в него уже забит логин и ключ API.*/
            string user = "X-Yandex-API-Key";
            string key = "2fc0daec-8f35-471a-b83f-a22d956e1697";

            // Текст запроса в формате XML
            string url = @"http://xmlsearch.yandex.ru/xmlsearch?
              query={0}&
              groupby=attr%3Dd.
              mode%3Ddeep.
              groups-on-page%3D10.
              docs-in-group%3D1&
              user={1}&
              key={2}";
            //Готовый текст запроса.
            string completeUrl = String.Format(url, searchQuery, user, key);


            var request = (HttpWebRequest)WebRequest.Create(completeUrl);
            var response = (HttpWebResponse)(await request.GetResponseAsync());

            var responseText = "";
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                responseText = reader.ReadToEnd();
            }

            return responseText;
        }

    }
}
