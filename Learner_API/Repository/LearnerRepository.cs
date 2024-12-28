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

            //try
            //{
            //    await _appDbContext.SEA_LearnerSubscriber.AddRangeAsync(learner);

            //    var result = await _appDbContext.SaveChangesAsync();
            //    //return result;

            //    if (result > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    return false;

            //}

            try
            {
                // Filter out records where SourceName is "mylearning"

                var filteredLearners = learner.Where(l => l.SourceName?.ToLower() != "mylearning").ToList();

                if (filteredLearners.Any())
                {
                    await _appDbContext.SEA_LearnerSubscriber.AddRangeAsync(filteredLearners);

                    var result = await _appDbContext.SaveChangesAsync();

                    return result > 0;
                }
                else
                {
                    // No valid records to insert
                    return true;
                }



            }
            catch (Exception ex)
            {
                // Log exception (if needed) and return false
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }



        }
    }
}


