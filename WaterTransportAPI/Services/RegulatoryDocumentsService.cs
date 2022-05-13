using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Text;
using WaterTransportAPI.Models;

namespace RegulatoryDocuments.Services
{
    public class RegulatoryDocumentsService
    {
        //private WeatherConfigs? configs; 
        List<RegulatoryDocumentsSource> regulatoryDocumentsSources = new List<RegulatoryDocumentsSource>();

        public RegulatoryDocumentsService()
        {
            regulatoryDocumentsSources.Add(new GovSPbRu());
            //var configFileText = File.ReadAllText("./Config/config.json");
            //var configFileJson = JObject.Parse(configFileText)?["Weather"];

            //configs = configFileJson?.ToObject<WeatherConfigs>();
        }

        public List<string> GetRegulatoryDocumentsAsync()
        {
            List<string> result = new List<string>();
            /*for (int i = 0; i < 10; i++)
            {
                result.Add(i.ToString());
            }*/
            foreach (var source in regulatoryDocumentsSources)
            {
                result.AddRange(source.parse().Result);
            }

            return result;
        }
    }
}