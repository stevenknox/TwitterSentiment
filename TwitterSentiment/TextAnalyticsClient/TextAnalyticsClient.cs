using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitterSentiment
{
    public class TextAnalyticsClient
    {
        private readonly IConfiguration _config;
        public HttpClient _client { get; }
        public TextAnalyticsClient(IConfiguration config, HttpClient client)
        {
            _client = client;
            _config = config;

            //ensure westus for now, have issues when its not
            _client.BaseAddress = new Uri("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/");
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config["AzureTextAnalytics"]);
        }

        //need unit test
        public async Task<AnalysisResult> AnalyzeSentiment(List<Document> documents)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(new DocumentWrapper { Documents = documents })))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _client.PostAsync("sentiment", content);

                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadAsAsync<AnalysisResult>();
            }
        }
    }
}