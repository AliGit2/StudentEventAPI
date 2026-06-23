namespace StudentEventAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int StudentId { get; set; }
        public int Rating { get; set; }        // 1 to 5
        public string Comment { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Event Event { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}