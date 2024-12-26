using Learner_API.Entity;
using Learner_API.Model;

namespace Learner_API.Interfaces
{
    public interface ILearnerRepository
    {
     //   Task<IEnumerable<LearnerModel>> GetAllLearnersAsync();
     //   Task<LearnerModel?> GetLearnerByIdAsync(string transcriptId);
        
        Task<bool> AddLearnerAsync(List<Learner> learner);
        

        //    Task<bool> UpdateLearnerAsync(LearnerModel learner);
        //    Task<bool> DeleteLearnerAsync(string transcriptId);

    }
}
