using StudentEventAPI.DTOs;

namespace StudentEventAPI.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationResponseDto> RegisterAsync(CreateRegistrationDto dto);
    }
}