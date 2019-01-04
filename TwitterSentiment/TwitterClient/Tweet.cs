namespace TwitterSentiment
{
   public class Tweet
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public Tweet(string id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}