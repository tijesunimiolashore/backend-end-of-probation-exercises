namespace event_scheduler_and_conflict_detector_api.Models
{
    public class AddEventDto
    {
		public required string Title { get; set; }

		public required string Description { get; set; }

		public required DateTime StartTime { get; set; }

		public required DateTime EndTime { get; set; }

		public required string Location { get; set; }

		public required List<String> Attendees { get; set; }

		public required Enum EventType { get; set; }
	}
}
