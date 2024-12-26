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
        public IActionResult Post([FromBody] LearnerModel learnerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                // If you want to pass a single LearnerModel object to the method, you need to wrap it in a list:
                var learners = _learnerService.AddLearnerAsync(new List<LearnerModel> { learnerModel });
                return StatusCode(StatusCodes.Status201Created, "learner Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}







