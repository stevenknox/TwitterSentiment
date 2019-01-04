using System.Collections.Generic;
using System.Linq;

namespace TwitterSentiment
{
    public static class Extensions
    {
        public static List<Document> ProjectToDocuments(this List<Tweet> tweets)
        {
            var docs = new List<Document>();

            tweets.ForEach(t=> docs.Add(new Document { Id = t.Id, Text = t.Text, Language = "en" }));

            return docs;
        }

        public static IEnumerable<TweetsWithSentiment> Combine(this List<Tweet> tweets, AnalysisResult sentiment)
        {
            var response = new List<TweetsWithSentiment>();

            return tweets.Join(sentiment.Documents, 
                                t => t.Id, 
                                s => s.Id, 
                                (t, s) => new TweetsWithSentiment(t.Id, t.Text, s.Score));

        }
    }
}