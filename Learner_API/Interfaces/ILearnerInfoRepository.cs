using Learner_API.Entity;
using Learner_API.Model;

namespace Learner_API.Interfaces
{
    public interface ILearnerInfoRepository
    {
        Task<List<Learner>> GetLearnerAsync();
    }
}
