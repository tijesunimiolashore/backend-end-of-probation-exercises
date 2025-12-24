using event_scheduler_and_conflict_detector_api.Models;
using event_scheduler_and_conflict_detector_api.Models.Entities;

namespace event_scheduler_and_conflict_detector_api.Data
{
    public class EventService: IEventService
	{
        private static readonly List<Event> newEvent = new List<Event>();

        public EventService()
        {
			newEvent.Add(new List<Event>("Event 1", "Music Concert", 2023-12-23, 2023-12-30, "Abuja", ["Tj", "Temi", "Timi"]), 1);
			newEvent.Add(new("Event 2", "Music Concert", 2023 - 12 - 23, 2023 - 12 - 30, "Lagos", ["A", "B", "C"]), 2);
			newEvent.Add(new("Event ", "Music Concert", 2023 - 12 - 23, 2023 - 12 - 30, "Kano", ["Tobi", "Tola", "Tomi"]), 3);
		}

		public List<Event> GetAllEvents()
		{
			return newEvent.ToList();
		}
	}
}
