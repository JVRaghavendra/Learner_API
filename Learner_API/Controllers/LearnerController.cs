using Learner_API.Interfaces;
using Learner_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        public ILearnerService _learnerService;

        public LearnerController(ILearnerService learnerService) 
        {
            _learnerService = learnerService;
        }

        [HttpPost]
        [Route("AddLearnerAsync")]
        public async Task<IActionResult> Post([FromBody] List<LearnerModel> learnerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                // If you want to pass a single LearnerModel object to the method, you need to wrap it in a list:

                var learners =await _learnerService.AddLearnerAsync(learnerModel);

                //return StatusCode(StatusCodes.Status201Created, "learner Details Added Succesfully");
                return Ok( learners);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}







