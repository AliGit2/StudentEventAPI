using Microsoft.AspNetCore.Mvc;
using StudentEventAPI.DTOs;
using StudentEventAPI.Services.Interfaces;

namespace StudentEventAPI.Controllers
{
    [ApiController]
    [Route("api/registrations")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // POST /api/registrations
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateRegistrationDto dto)
        {
            try
            {
                var result = await _registrationService.RegisterAsync(dto);
                return CreatedAtAction(nameof(Register), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}