namespace TwitterSentiment
{
  public class TweetsWithSentiment
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public double Score { get; set; }

        public TweetsWithSentiment(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public TweetsWithSentiment(string id, string text, double score)
        {
            Id = id;
            Text = text;
            Score = score;
        }
    }
}