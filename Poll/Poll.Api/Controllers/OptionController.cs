using Microsoft.AspNetCore.Mvc;
using Poll.Application.Services;

namespace Poll.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionController(IOptionService optionService) : ControllerBase
    {
        [HttpPost("{optionId}")]
        public async Task<IActionResult> Vote([FromRoute] Guid optionId)
        {
            var result = await optionService.AddVote(optionId);

            if (result.Failed && result.FailureMessage.Contains("Option not found"))
                return NotFound("Option not found");

            return NoContent();
        }

        [HttpGet("{pollId}")]
        public async Task<IActionResult> GetOptionsByPoll([FromRoute] Guid pollId)
            => Ok(await optionService.OptionsByPollId(pollId));
    }
}