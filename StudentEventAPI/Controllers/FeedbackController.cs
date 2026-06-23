using Microsoft.AspNetCore.Mvc;
using StudentEventAPI.DTOs;
using StudentEventAPI.Services.Interfaces;

namespace StudentEventAPI.Controllers
{
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // POST /api/feedback
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] CreateFeedbackDto dto)
        {
            try
            {
                var result = await _feedbackService.SubmitFeedbackAsync(dto);
                return CreatedAtAction(nameof(Submit), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}