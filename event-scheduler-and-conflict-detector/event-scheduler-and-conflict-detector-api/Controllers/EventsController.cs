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
		//Adds a New Event
		public IActionResult AddAllEvents(AddEventDto addEventDto)
		{
			if (!newEvent.Title.Equals("") && newEvent.StartTime < newEvent.EndTime)
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
					foreach (var i in myEvent){
						if (i.StartTime <= i.EndTime)
						{
							myEvent.Add(addEvent);
						}
						else
						{
							return Conflict(409);
						}

					}
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex);
				}
			};
			return Ok("Added Event Succesfully");
		}

		[HttpGet]
		//Get All Events
		public IActionResult GetAllEvents()
		{
			var events = myEvent.ToList().OrderBy(newEvent.StartTime);

			return Ok(events);
		}

		[HttpGet]
		[Route("{startTime: DateTime}")]
		[Route("{endTime: DateTime}")]
		//Get All Events within a Specific Range
		public IActionResult GetAllEventsByDate(DateTime startTime, DateTime endTime)
		{
			var objectOfFind = myEvent.Where(startTime => newEvent.StartTime.Equals("2020-12-23") && endTime => newEvent.EndTime.Equals("2020-12-30"));

			if (objectOfFind is null)
			{
				return NotFound();
			}
			return Ok(objectOfFind);
		}

		[HttpPut]
		//Update an Existing Event
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
		//Remove and Existing Record
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
