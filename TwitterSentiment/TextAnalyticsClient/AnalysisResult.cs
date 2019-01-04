using System.Collections.Generic;

namespace TwitterSentiment
{
    public class AnalysisResult
    {
        public List<DocumentAnalysis> Documents { get; set; }
        public List<Error> Errors { get; set; }
    }
    public class DocumentAnalysis
    {
        public string Id { get; set; }
        public double Score { get; set; }
    }
    public class Error
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}