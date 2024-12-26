using System.Diagnostics.CodeAnalysis;

namespace Learner_API.Model
{
    [ExcludeFromCodeCoverage]

    public class LearnerModel
    {
        public string? TranscriptID { get; set; }
        public string? Employee_ID { get; set; }
        public int? People_Key { get; set; }
        public string? CourseID { get; set; }
        public string? SessionID { get; set; }
        public string? Status { get; set; }
        public long? CompletionDate { get; set; }
        public int? SourceID { get; set; }
        public string? SourceName { get; set; }
    }
}
