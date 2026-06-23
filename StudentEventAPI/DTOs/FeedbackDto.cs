namespace StudentEventAPI.DTOs
{
    public class CreateFeedbackDto
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }
        public int Rating { get; set; }      // must be 1-5
        public string Comment { get; set; } = string.Empty;
    }

    public class FeedbackResponseDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
    }
}