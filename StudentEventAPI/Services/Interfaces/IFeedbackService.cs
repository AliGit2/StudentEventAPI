using StudentEventAPI.DTOs;

namespace StudentEventAPI.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponseDto> SubmitFeedbackAsync(CreateFeedbackDto dto);
    }
}