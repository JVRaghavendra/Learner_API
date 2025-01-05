using Learner_API.Entity;
using Learner_API.Model;

namespace Learner_API.Interfaces
{
    public interface ILearnerInfoService
    {
        Task<List<LearnerModel>> GetLearnerAsync();
    }
}
