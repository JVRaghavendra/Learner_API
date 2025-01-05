using Learner_API.DBContext;
using Learner_API.Entity;
using Learner_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Learner_API.Repository
{
    public class LearnerInfoRepository : ILearnerInfoRepository
    {

        private readonly AppDbContext _appDbContext;

        public LearnerInfoRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }
        public async Task<List<Learner>> GetLearnerAsync()
        {
            try
            {
                // Fetch top 10 learners matching the criteria

                var learners = await _appDbContext.SEA_LearnerSubscriber
                    .Where(x => x.IsProcessed == false
                                && x.Status == "Completed"
                              && x.LearnerID != null // Employee ID not null
                              && x.CompletionDate != null) // CompletionDate not null
                    .OrderBy(x => x.SubscribedDateTime)
                    .Take(10)
                    .ToListAsync();

                return learners ?? new List<Learner>();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new Exception("An error occurred while fetching learners.", ex);
            }
        }

        //public async Task<List<Learner>> GetLearnerAsync()
        //{
        //    try
        //    {
        //        // Fetch top 10 learners matching the criteria
        //        var learners = await _appDbContext.SEA_LearnerSubscriber
        //            .Where(x => x.IsProcessed == false
        //                        && x.Status == "Completed"
        //                        && x.LearnerID != null // Employee ID not null
        //                        && x.CompletionDate != null) // CompletionDate not null
        //            .OrderBy(x => x.SubscribedDateTime)
        //            .Take(10)
        //            .ToListAsync();

        //        // If learners are found, mark them as processed
        //        if (learners.Any())
        //        {
        //            // Update IsProcessed to true for matching CourseID (Condition 2)
        //            var courseIds = learners.Select(l => l.CourseID).ToList();

        //            var recordsToUpdate = await _appDbContext.SEA_LearnerSubscriber
        //                .Where(x => courseIds.Contains(x.CourseID))
        //                .ToListAsync();

        //            foreach (var record in recordsToUpdate)
        //            {
        //                record.IsProcessed = true;
        //            }

        //            // Save the changes
        //            await _appDbContext.SaveChangesAsync();
        //        }

        //        return learners ?? new List<Learner>();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (optional)
        //        throw new Exception("An error occurred while fetching or updating learners.", ex);
        //    }
        //}



    }
}


//    // If learners are found, mark them as processed
//    if (learners.Any())
//    {
//        // Update IsProcessed to true for matching CourseID (Condition 2)
//        var courseIds = learners.Select(l => l.CourseID).ToList();

//        var recordsToUpdate = await _appDbContext.SEA_LearnerSubscriber
//            .Where(x => courseIds.Contains(x.CourseID))
//            .ToListAsync();

//        foreach (var record in recordsToUpdate)
//        {
//            record.IsProcessed = true;
//        }

//        // Save the changes
//        await _appDbContext.SaveChangesAsync();
//    }

//    return learners ?? new List<Learner>();
//}
//catch (Exception ex)
//{
//    // Log the exception (optional)
//    throw new Exception("An error occurred while fetching or updating learners.", ex);
//}