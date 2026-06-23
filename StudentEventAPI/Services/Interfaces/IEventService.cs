using StudentEventAPI.DTOs;

namespace StudentEventAPI.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<EventResponseDto>> GetAllUpcomingEventsAsync();
        Task<EventResponseDto?> GetEventByIdAsync(int id);
        Task<EventResponseDto> CreateEventAsync(CreateEventDto dto);
        Task<EventResponseDto?> UpdateEventAsync(int id, UpdateEventDto dto);
        Task<bool> DeleteEventAsync(int id);
        Task<List<EventResponseDto>> SearchEventsAsync(string query);
        Task<List<EventResponseDto>> FilterEventsByDateAsync();
    }
}