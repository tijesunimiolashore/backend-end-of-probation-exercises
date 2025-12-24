namespace event_scheduler_and_conflict_detector_api.Models
{
    public class UpdateEventDto
    {
		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public string Location { get; set; }

		public List<String> Attendees { get; set; }

		public Enum EventType { get; set; }
	}
}
