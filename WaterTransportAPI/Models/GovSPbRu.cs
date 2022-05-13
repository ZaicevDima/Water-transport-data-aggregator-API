using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WaterTransportAPI.Models
{
    public class GovSPbRu : RegulatoryDocumentsSource
    {
        private string url = "https://www.gov.spb.ru/gov/otrasl/c_transport/vodnyj-transport/";

        async Task<string> getContent()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            var content = await client.GetStringAsync(url);

            //Console.WriteLine(content);
            return content.ToString();
        }

        async Task<List<string>> RegulatoryDocumentsSource.parse()
        {
            using var context = BrowsingContext.New(Configuration.Default);
            string html = await getContent();
            using var doc = await context.OpenAsync(req => req.Content(html));
            List<string> result = new List<string>();

            var links = doc.GetElementsByClassName("block content").First().QuerySelectorAll("p");

            foreach (var link in links)
            {
                string htmlLink = link.ToHtml();
                //string url = h
                result.Add(link.ToHtml());
            }
            return result;
        }
    }
}
