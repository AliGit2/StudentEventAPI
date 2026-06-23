namespace StudentEventAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }

        // Navigation properties
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}