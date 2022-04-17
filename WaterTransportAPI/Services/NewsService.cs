using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Text;
using WaterTransportAPI.Models;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

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

        public async Task<List<NewsResponse>> GetNewsAsync(string searchQuery)
        {
            searchQuery = "\"" + searchQuery.Replace(",", "\" AND \"") + "\"";

            var result = new List<NewsResponse>();

            var newsApiClient = new NewsApiClient("");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = searchQuery,
                SortBy = SortBys.Popularity,
                Language = Languages.RU,
                From = new DateTime(2022, 03, 18)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {

                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    var newsResponse = new NewsResponse();

                    newsResponse.Url = article.Url;
                    newsResponse.Author = article.Author;
                    newsResponse.Title = article.Title;
                    newsResponse.Description = article.Description;

                    result.Add(newsResponse);
                }
            }

            return result;
        }
    }
}
