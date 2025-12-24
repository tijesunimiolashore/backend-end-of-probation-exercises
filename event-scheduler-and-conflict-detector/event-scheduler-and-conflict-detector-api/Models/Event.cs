namespace event_scheduler_and_conflict_detector_api.Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();

		public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public List<String> Attendees { get; set; }

        public enum EventType { get; set; }

        public Event()
        {
            
        }
		public Event(Guid id, string title, string description, DateTime startTime, DateTime endTime, string location, List<string> attendees)
		{
			Id = id;
			Title = title;
			Description = description;
			StartTime = startTime;
			EndTime = endTime;
			Location = location;
			Attendees = attendees;
		}

	}
}
