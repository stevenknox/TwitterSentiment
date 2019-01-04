using Newtonsoft.Json;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tests.Fakes;
using TwitterSentiment;
using Xunit;

namespace Tests
{
    public class TwitterClientShould
    {
        public TwitterClientShould()
        {
        }

        [Fact]
        public async Task Get_Tweets_For_Hastag_Using_TypedHttpClient()
        {
            var tweet1 = new Tweet("1", "This is a really negative tweet");
            var tweet2 = new Tweet("2", "This is a super positive great tweet");
            var tweet3 = new Tweet("3", "This is another really super positive amazing tweet");

            var tweets = new List<Tweet> { tweet1, tweet2, tweet3  };

            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(tweets), Encoding.UTF8, "application/json")
            });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            var sut = new TwitterClient(fakeHttpClient);

            var result = await sut.GetTimeline("wholeschool");

            result.Count.ShouldBe(3);
        }
       
    }
}
