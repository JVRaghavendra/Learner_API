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
                await _appDbContext.SEA_LearnerSubscriber.AddRangeAsync(learner);

                var result = await _appDbContext.SaveChangesAsync();
                //return result;

                if(result == 0) 
                { 
                 return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;

            }

        }
    }
}
