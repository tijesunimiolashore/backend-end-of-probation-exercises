using System.Linq;
using event_scheduler_and_conflict_detector_api.Models;
using event_scheduler_and_conflict_detector_api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace event_scheduler_and_conflict_detector_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private static readonly List<Event> myEvent = new List<Event>();
		public Event newEvent = new Event();

		[HttpPost]
		public IActionResult AddAllEvents(AddEventDto addEventDto)
		{
			if (newEvent.Title is not null && newEvent.StartTime < newEvent.EndTime)
			{
				var addEvent = new Event()
				{
					Id = Guid.NewGuid(),
					Title = addEventDto.Title,
					Description = addEventDto.Description,
					StartTime = addEventDto.StartTime,
					EndTime = addEventDto.EndTime,
					Location = addEventDto.Location,
					Attendees = addEventDto.Attendees,
					EventType = addEventDto.EventType
				};
				try
				{
					myEvent.Add(addEvent);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex);
				}
			};
			return Ok("Added Event Succesfully");
		}

		[HttpGet]
		public IActionResult GetAllEvents()
		{
			var events = myEvent.ToList().OrderBy(newEvent.StartTime);

			return Ok(events);
		}

		[HttpGet]
		[Route("{startTime: DateTime}")]
		[Route("{endTime: DateTime}")]
		public IActionResult GetAllEventsByDate(DateTime startTime, DateTime endTime)
		{
			var objectOfFind = myEvent.Where(startTime => newEvent.StartTime.Equals("2020-12-23") && endTime => newEvent.EndTime.Equals("2023-12-30"));

			if (objectOfFind is null)
			{
				return NotFound();
			}
			return Ok(objectOfFind);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public IActionResult UpdateEvents(Guid id, UpdateEventDto updateEventDto)
		{
			var objectOfFind = myEvent.Where(x => x.Id == id).FirstOrDefault();

			if (objectOfFind is null)
			{
				return NotFound();
			}

			objectOfFind.Id = Guid.NewGuid();
			objectOfFind.Title = updateEventDto.Title;
			objectOfFind.Description = updateEventDto.Description;
			objectOfFind.StartTime = updateEventDto.StartTime;
			objectOfFind.EndTime = updateEventDto.EndTime;
			objectOfFind.Location = updateEventDto.Location;
			objectOfFind.Attendees = updateEventDto.Attendees;
			objectOfFind.EventType = updateEventDto.EventType;

			return Ok(objectOfFind);
		}

		[HttpDelete]
		public IActionResult DeleteEvents(Guid id)
		{
			var objectOfFind = myEvent.Where(x => x.Id == id).FirstOrDefault();

			if (objectOfFind is null)
			{
				return NotFound();
			}
			myEvent.Remove(objectOfFind);
			return Ok(objectOfFind);
		}
	}
}
