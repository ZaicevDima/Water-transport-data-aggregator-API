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
        }

        public List<string> GetRegulatoryDocuments()
        {
            List<string> result = new List<string>();
            
            foreach (var source in regulatoryDocumentsSources)
            {
                Console.WriteLine(source.parse());
                result.AddRange(source.parse().Result);
            }

            return result;
        }

        public DocResult parse()
        {
            DocResult result = new DocResult();
            var regulatoryDocuments = GetRegulatoryDocuments();

            foreach (var regulatoryDocument in regulatoryDocuments)
            {
                var docElement = new DocElementResult();
                var index = regulatoryDocument.IndexOf("<a href=\"");
                if (index == -1)
                {
                    continue;
                }
                //string s = regulatoryDocument
                string tmp = regulatoryDocument.Substring(index + "<a href=\"".Length);
                docElement.Url = "https://www.gov.spb.ru" + tmp[..tmp.IndexOf("\">")];

                tmp = tmp.Substring(tmp.IndexOf("\">") + "\">".Length);
                docElement.Title = tmp[..tmp.IndexOf("</a></p>")].Replace("&nbsp;", " ").Replace("\"", "'");

                result.DocElements.Add(docElement);
            }

            return result;
        }
    }
}