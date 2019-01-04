using System.Collections.Generic;

namespace TwitterSentiment
{

    public class DocumentWrapper
    {
        public List<Document> Documents { get; set; }
    }
    public class Document
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }
}