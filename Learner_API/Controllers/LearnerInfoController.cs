using Learner_API.Interfaces;
using Learner_API.Model;
using Learner_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnerInfoController : ControllerBase
    {
        private readonly ILearnerInfoService _learnerInfoService;

        public LearnerInfoController(ILearnerInfoService learnerInfoService)
        {
            _learnerInfoService = learnerInfoService;

        }


        [HttpGet]
        [Route("GetLearnerAsync")]

        public async Task<IActionResult> Get()
        {

            try
            {
                // Fetch learners from the service
                var learners = await _learnerInfoService.GetLearnerAsync();



                // If no learners are found, return NotFound

                if (learners == null || !learners.Any())
                {
                    return NotFound("No learners found matching the criteria.");
                }
                // If learners found, return 200 OK with learners list

                return Ok(learners);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }

            //try
            //{

            //    // If you want to pass a single LearnerModel object to the method, you need to wrap it in a list:

            //   var learners = await _learnerInfoService.GetLearnerAsync();

            //   // return StatusCode(StatusCodes.Status201Created, "learner Details Added Succesfully");

            //    return Ok(learners);

            //    //(1)get data from leranertable based on isprocess is false and status is completed

            //    //(2) update isprocess to true once you got records basedon pk


            //    //(3)Add  fileter for result 1 conditions are like cmpleteddat is not null and skill is not null and coursid is notnull 
            //}//cousre4 = pass courseid from result 3 and get the data
            ////skill5 = pass courseid form result 3


            ////foreachlook for reslt 3 inside forachloop based on each itertion check record is available in result 4 and 5 if it is available in both
            ////mapp to wdlcomputeddata



            ////return type must be List<wdlcomputeddata>


            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            //}

        }
    }


}


