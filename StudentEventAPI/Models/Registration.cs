namespace StudentEventAPI.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Event Event { get; set; } = null!;
    }
}