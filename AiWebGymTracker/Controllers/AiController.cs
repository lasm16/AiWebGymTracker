using AiWebGymTracker.Abstractions;
using AiWebGymTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiWebGymTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AiController : ControllerBase
    {
        private readonly ILogger<AiController> _logger;
        private readonly IAiService _aiService;

        public AiController(ILogger<AiController> logger, IAiService aiService)
        {
            _logger = logger;
            _aiService = aiService;
        }

        [HttpPost(Name = "CreateTrainingPlan")]
        public async Task<IActionResult> CreateTrainingPlan(UserStatsInput input)
        {
            var response = await _aiService.AskAi<UserStatsInput, object>(input);
            return Ok(response);
        }
        //      {
        //"messages": [
        //  "Параметры пользователя для составления плана тренировок. Представь, что ты - фитнесс тренер"
        //],
        //"age": 24,
        //"weight": 81,
        //"height": 193,
        //"gender": 1,
        //"level": 1,
        //"goals": [
        //  "накачать мышцы"
        //]
        //  }
    }
}
