using StudentEventAPI.Data;
using StudentEventAPI.DTOs;
using StudentEventAPI.Models;
using StudentEventAPI.Services.Interfaces;

namespace StudentEventAPI.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext _context;
        public FeedbackService(AppDbContext context) { _context = context; }

        public async Task<FeedbackResponseDto> SubmitFeedbackAsync(CreateFeedbackDto dto)
        {
            // Validate rating
            if (dto.Rating < 1 || dto.Rating > 5)
                throw new ArgumentException("Rating must be between 1 and 5.");

            // Check event exists
            var ev = await _context.Events.FindAsync(dto.EventId)
                ?? throw new KeyNotFoundException("Event not found.");

            // Only allow feedback after event date
            if (ev.EventDate > DateTime.UtcNow)
                throw new InvalidOperationException("Feedback can only be submitted after the event has occurred.");

            // Check student exists
            var student = await _context.Students.FindAsync(dto.StudentId)
                ?? throw new KeyNotFoundException("Student not found.");

            var feedback = new Feedback
            {
                EventId = dto.EventId,
                StudentId = dto.StudentId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                SubmittedAt = DateTime.UtcNow
            };
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return new FeedbackResponseDto
            {
                Id = feedback.Id,
                EventId = feedback.EventId,
                EventTitle = ev.Title,
                StudentId = feedback.StudentId,
                StudentName = student.Name,
                Rating = feedback.Rating,
                Comment = feedback.Comment,
                SubmittedAt = feedback.SubmittedAt
            };
        }
    }
}