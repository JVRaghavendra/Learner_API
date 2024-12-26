﻿using Learner_API.Entity;
using Learner_API.Interfaces;
using Learner_API.Model;
using System.Text.Json;

namespace Learner_API.Service
{
    public class LearnerService : ILearnerService
    {

        private readonly ILearnerRepository _learnerRepository;

        public LearnerService(ILearnerRepository learnerRepository)
        {
            _learnerRepository = learnerRepository;
        }

        public async Task<bool> AddLearnerAsync(List<LearnerModel> learnerModel)
        {


            //try
            //{

                var entities = new List<Learner>();
                var result = false;

            foreach (var model in learnerModel)
                {

                    var entity = new Learner();
                    {

                    entity.SubscriberID = Convert.ToInt64(model.SourceID);
                    entity.TranscriptID = model.TranscriptID;
                    entity.LearnerID = model.Employee_ID;
                    entity.PeopleKey = model.People_Key;
                    entity.CourseID = model.CourseID;
                    entity.SessionID = model.SessionID;
                    entity.Status = int.Parse(model.Status);
                    entity.CompletionDate = model.CompletionDate;
                    entity.SourceID = model.SourceID;
                    entity.SourceName = model.SourceName;
                    entity.SubscribedDateTime = DateTimeOffset.UtcNow; ;
                    entity.Payload = JsonSerializer.Serialize(model);
                    entity.IsProcessed = false;


                    entities.Add(entity);

                    }

                    result = await _learnerRepository.AddLearnerAsync(entities);
                }

                
                return result;
           // }

            //catch (Exception ex)
            //{
            //    // Log the exception (optional: use a logging framework like Serilog or NLog)
            //    Console.WriteLine($"Error occurred while adding learners: {ex.Message}");
        
            //     // Return false to indicate failure
            //     return false;

            //}



        }
    }
}