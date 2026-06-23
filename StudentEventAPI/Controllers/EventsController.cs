using Microsoft.AspNetCore.Mvc;
using StudentEventAPI.DTOs;
using StudentEventAPI.Services.Interfaces;

namespace StudentEventAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService) { _eventService = eventService; }

        // GET /api/events
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllUpcomingEventsAsync();
            return Ok(events);
        }

        // GET /api/events/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null) return NotFound(new { message = "Event not found." });
            return Ok(ev);
        }

        // POST /api/events
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            var ev = await _eventService.CreateEventAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ev.Id }, ev);
        }

        // PUT /api/events/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEventDto dto)
        {
            var ev = await _eventService.UpdateEventAsync(id, dto);
            if (ev == null) return NotFound(new { message = "Event not found." });
            return Ok(ev);
        }

        // DELETE /api/events/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventService.DeleteEventAsync(id);
            if (!result) return NotFound(new { message = "Event not found." });
            return Ok(new { message = "Event deleted successfully." });
        }

        // GET /api/events/search?query=xyz
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var events = await _eventService.SearchEventsAsync(query);
            return Ok(events);
        }

        // GET /api/events/filter?sort=date
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] string sort)
        {
            var events = await _eventService.FilterEventsByDateAsync();
            return Ok(events);
        }
    }
}