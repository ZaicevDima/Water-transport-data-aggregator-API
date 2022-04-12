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
            string user = "tigr53310";
            string key = "03.377715118:f7e295478d08c739b21c3bdefd812c55";

            // Текст запроса в формате XML
            string url = $@"https://yandex.ru/search/xml?user={user}&key={key}&query={searchQuery}&l10n=ru&sortby=tm.order%3Dascending&filter=strict&groupby=attr%3D%22%22.mode%3Dflat.groups-on-page%3D10.docs-in-group%3D1&page=2";

            string completeUrl = String.Format(url, searchQuery, user, key);


            var request = (HttpWebRequest)WebRequest.Create(completeUrl);
            var response = (HttpWebResponse)(await request.GetResponseAsync());

            var responseText = "";
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                responseText = reader.ReadToEnd();
            }

            Console.WriteLine(responseText);

            return responseText;
        }

    }
}
