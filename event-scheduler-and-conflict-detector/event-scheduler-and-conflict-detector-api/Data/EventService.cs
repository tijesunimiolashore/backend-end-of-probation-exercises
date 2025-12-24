using event_scheduler_and_conflict_detector_api.Models;
using event_scheduler_and_conflict_detector_api.Models.Entities;

namespace event_scheduler_and_conflict_detector_api.Data
{
    public class EventService: IEventService
	{
        private static readonly List<Event> newEvent = new List<Event>();

        public EventService()
        {
		}

		public List<Event> GetAllEvents()
		{
			return newEvent.ToList();
		}
	}
}
