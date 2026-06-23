using Microsoft.EntityFrameworkCore;
using StudentEventAPI.Data;
using StudentEventAPI.DTOs;
using StudentEventAPI.Models;
using StudentEventAPI.Services.Interfaces;

namespace StudentEventAPI.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context) { _context = context; }

        public async Task<List<EventResponseDto>> GetAllUpcomingEventsAsync()
        {
            return await _context.Events
                .Where(e => e.EventDate >= DateTime.UtcNow)
                .Select(e => new EventResponseDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Venue = e.Venue,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,
                    RegisteredCount = e.Registrations.Count
                }).ToListAsync();
        }

        public async Task<EventResponseDto?> GetEventByIdAsync(int id)
        {
            var e = await _context.Events.Include(e => e.Registrations)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (e == null) return null;
            return new EventResponseDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Venue = e.Venue,
                EventDate = e.EventDate,
                Capacity = e.Capacity,
                RegisteredCount = e.Registrations.Count
            };
        }

        public async Task<EventResponseDto> CreateEventAsync(CreateEventDto dto)
        {
            var ev = new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                Venue = dto.Venue,
                EventDate = dto.EventDate,
                Capacity = dto.Capacity
            };
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return new EventResponseDto
            {
                Id = ev.Id,
                Title = ev.Title,
                Description = ev.Description,
                Venue = ev.Venue,
                EventDate = ev.EventDate,
                Capacity = ev.Capacity
            };
        }

        public async Task<EventResponseDto?> UpdateEventAsync(int id, UpdateEventDto dto)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return null;
            ev.Title = dto.Title; ev.Description = dto.Description;
            ev.Venue = dto.Venue; ev.EventDate = dto.EventDate; ev.Capacity = dto.Capacity;
            await _context.SaveChangesAsync();
            return new EventResponseDto
            {
                Id = ev.Id,
                Title = ev.Title,
                Description = ev.Description,
                Venue = ev.Venue,
                EventDate = ev.EventDate,
                Capacity = ev.Capacity
            };
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return false;
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EventResponseDto>> SearchEventsAsync(string query)
        {
            return await _context.Events
                .Where(e => e.Title.Contains(query) || e.Venue.Contains(query))
                .Select(e => new EventResponseDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Venue = e.Venue,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,
                    RegisteredCount = e.Registrations.Count
                }).ToListAsync();
        }

        public async Task<List<EventResponseDto>> FilterEventsByDateAsync()
        {
            return await _context.Events
                .OrderBy(e => e.EventDate)
                .Select(e => new EventResponseDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Venue = e.Venue,
                    EventDate = e.EventDate,
                    Capacity = e.Capacity,
                    RegisteredCount = e.Registrations.Count
                }).ToListAsync();
        }
    }
}