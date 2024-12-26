using Learner_API.DBContext;
using Learner_API.Entity;
using Learner_API.Interfaces;
using Learner_API.Model;

namespace Learner_API.Repository
{
    public class LearnerRepository : ILearnerRepository
    {
        private readonly AppDbContext _appDbContext;

        public LearnerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }     

        public async Task<bool> AddLearnerAsync(List<Learner> learner)
        {
            try
            {
                _appDbContext.SEA_LearnerSubscriber.AddRangeAsync(learner);
                _appDbContext.SaveChanges();
                return true;

            }
            catch (Exception ex) 
            { 
            
                return false;

            }
            
        }
    }
}
