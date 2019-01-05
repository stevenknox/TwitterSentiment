using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tests.Fakes;
using TwitterSentiment;
using Xunit;

namespace Tests
{
    public class TextAnalyticsClientShould
    {
        public TextAnalyticsClientShould()
        {
        }

        [Fact]
        public async Task Get_Sentiment_Analysis_Results_Using_TypedHttpClient()
        {
            var document1 = new Document { Id = "1", Text = "This is a really negative tweet", Language = "en-gb" };
            var document2 = new Document { Id = "2", Text = "This is a super positive great tweet", Language = "en-gb" };
            var document3 = new Document { Id = "3", Text = "This is another really super positive amazing tweet", Language = "en-gb" };
            
            var result1 = new DocumentAnalysis { Id = "1", Score = 0 };
            var result2 = new DocumentAnalysis { Id = "2", Score = 0.7 };
            var result3 = new DocumentAnalysis { Id = "3", Score = 0.9 };

            var documents = new List<Document> { document1, document2, document3  };
            var results = new AnalysisResult { Documents = new List<DocumentAnalysis> { result1, result2, result3 }  };

            var fakeConfiguration = Substitute.For<IConfiguration>();

            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(results), Encoding.UTF8, "application/json")
            });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            var sut = new TextAnalyticsClient(fakeConfiguration, fakeHttpClient);

            var result = await sut.AnalyzeSentiment(documents);

            result.Documents.Count.ShouldBe(3);
            result.Documents.ShouldContain(f=> f.Id == result1.Id && f.Score == result1.Score);
        }
       
    }
}
