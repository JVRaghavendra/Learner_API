using Learner_API.Entity;
using Learner_API.Interfaces;
using Learner_API.Model;
using Learner_API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Learner_API.Service
{
    public class LearnerInfoService : ILearnerInfoService
    {
        private readonly ILearnerInfoRepository _learnerInfoRepository;

        public LearnerInfoService(ILearnerInfoRepository learnerInfoRepository)
        {
            _learnerInfoRepository = learnerInfoRepository;
        }
        public async Task<List<LearnerModel>> GetLearnerAsync()
        {
            try
            {
                // Fetch entities from the repository with the same filtering
                var learners = await _learnerInfoRepository.GetLearnerAsync();

                // Map Learner entities to LearnerModel
                var learnerModels = learners.Select(model => new LearnerModel
                {
                    TranscriptID = model.TranscriptID,
                    Employee_ID = model.LearnerID,
                    PeopleKey = model.PeopleKey,
                    CourseID = model.CourseID,
                    SessionID = model.SessionID,
                    Status = model.Status,
                    CompletionDate = model.CompletionDate,
                    SourceID = model.SourceID,
                    SourceName = model.SourceName
                }).ToList();

                return learnerModels;
            }
            catch (Exception ex)
            {
                // Log and rethrow the exception
                throw new Exception("An error occurred while processing learners.", ex);
            }
        }




    }
}
