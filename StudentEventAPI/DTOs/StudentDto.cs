namespace StudentEventAPI.DTOs
{
    public class CreateStudentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
    }

    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
    }
}