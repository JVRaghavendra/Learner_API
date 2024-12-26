using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Learner_API.Entity
{
    [ExcludeFromCodeCoverage]
    [Table("SEA_LearnerSubscriber")]
    public class Learner
    {
        [Key]
        public long SubscriberID { get; set; }
        public string TranscriptID { get; set; }
        public string LearnerID { get; set; }
        public int? PeopleKey { get; set; }
        public string CourseID { get; set; }
        public string SessionID { get; set; }
        public int? Status { get; set; }
        public long? CompletionDate { get; set; }
        public int? SourceID { get; set; }
        public string SourceName { get; set; }
        public DateTimeOffset? SubscribedDateTime { get; set; }
        public string Payload { get; set; }
        public bool IsProcessed { get; set; }
    }
}
