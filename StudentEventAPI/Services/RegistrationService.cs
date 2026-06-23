using Microsoft.EntityFrameworkCore;
using StudentEventAPI.Data;
using StudentEventAPI.DTOs;
using StudentEventAPI.Models;
using StudentEventAPI.Services.Interfaces;

namespace StudentEventAPI.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _context;
        public RegistrationService(AppDbContext context) { _context = context; }

        public async Task<RegistrationResponseDto> RegisterAsync(CreateRegistrationDto dto)
        {
            // Check duplicate
            var exists = await _context.Registrations
                .AnyAsync(r => r.StudentId == dto.StudentId && r.EventId == dto.EventId);
            if (exists)
                throw new InvalidOperationException("Student is already registered for this event.");

            // Check event exists
            var ev = await _context.Events.FindAsync(dto.EventId)
                ?? throw new KeyNotFoundException("Event not found.");

            // Check student exists
            var student = await _context.Students.FindAsync(dto.StudentId)
                ?? throw new KeyNotFoundException("Student not found.");

            var reg = new Registration
            {
                StudentId = dto.StudentId,
                EventId = dto.EventId,
                RegisteredAt = DateTime.UtcNow
            };
            _context.Registrations.Add(reg);
            await _context.SaveChangesAsync();

            return new RegistrationResponseDto
            {
                Id = reg.Id,
                StudentId = reg.StudentId,
                StudentName = student.Name,
                EventId = reg.EventId,
                EventTitle = ev.Title,
                RegisteredAt = reg.RegisteredAt
            };
        }
    }
}