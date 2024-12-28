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
       
        public int SubscriberID { get; set; }

        [MaxLength(255)]
        public string? TranscriptID { get; set; }

        [MaxLength(255)]
        public string? LearnerID { get; set; }

        public int? PeopleKey { get; set; }

        [MaxLength(255)]
        public string? CourseID { get; set; }

        [MaxLength(255)]
        public string? SessionID { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        public long? CompletionDate { get; set; }

        public int? SourceID { get; set; }

        [MaxLength(255)]
        public string? SourceName { get; set; }

        public DateTime? SubscribedDateTime { get; set; }

        public string? Payload { get; set; }

        public bool? IsProcessed { get; set; }
    }
}
