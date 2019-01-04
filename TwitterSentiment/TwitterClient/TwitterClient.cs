using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitterSentiment
{
    public class TwitterClient
    {
        public HttpClient Client { get; }

        public TwitterClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.twitter.com/1.1/");
            Client = client;
        }

        public async Task<List<Tweet>> GetTimeline(string username)
        {
            var response = await Client.GetAsync($"statuses/user_timeline.json?include_rts=true&screen_name={username}&count=20");

            response.EnsureSuccessStatusCode();

            var tweets = await response.Content.ReadAsAsync<List<Tweet>>();

            return tweets;
        }
    }
}
