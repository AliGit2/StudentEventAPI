namespace StudentEventAPI.DTOs
{
    public class CreateRegistrationDto
    {
        public int StudentId { get; set; }
        public int EventId { get; set; }
    }

    public class RegistrationResponseDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }
    }
}