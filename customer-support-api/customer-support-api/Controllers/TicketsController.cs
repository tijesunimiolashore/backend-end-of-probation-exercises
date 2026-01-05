using System.Collections.Specialized;
using System.Net.Sockets;
using customer_support_api.DTO;
using customer_support_api.Enums;
using customer_support_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customer_support_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		private readonly List<Ticket> _ticketList = new();
		private readonly ILogger logger;

		public TicketsController(ILogger ilogger) {
			logger = ilogger;
		}


		[HttpPost]
		public IActionResult addTickets(Ticket myticket)
		{

			logger.LogInformation("Add a new instance for ticket");
			try
			{
				if (myticket.Subject.Equals("") && myticket.Description.Equals("")) {
					logger.LogError("Subject and Description cannot be empty");
				}
				var ticket = new Ticket("2", "Maiden", "A Mall Ticket", (Status) 3);
				_ticketList.Add(ticket);
				return Ok(ticket);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				return NotFound("Cannot add item");
			}
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult getTicketById(string id)
		{
			logger.LogInformation("Get a new instance for ticket by Id");

			try
			{
				var ticket = _ticketList.Find(t => t.Id == id);

				if (ticket == null)
				{
					logger.LogError("Ticket not found with Id: {Id}", id);
					return NotFound("Ticket not found");
				}
				return Ok(ticket);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Cannot find item");
			}
		}

		[HttpPut]
		public IActionResult updateTicket(string? id, Ticket myTicket) {
			logger.LogInformation("Update instance for ticket by Id");
			try
			{
				var ticket = _ticketList.Find(t => t.Id == id);

				if (ticket == null)
				{
					logger.LogError("Ticket not found with Id: {Id}", id);
					return NotFound("Ticket not found");
				}
				ticket.Subject = myTicket.Subject;
				ticket.Description = myTicket.Id;
				ticket.Status = myTicket.Status;
				ticket.CreatedAt = DateTime.UtcNow;
				return Ok(ticket);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Cannot update item");
			}
		}

		[HttpDelete]
		public IActionResult deleteTicket(string id) {
			logger.LogInformation("Delete instance for ticket by Id");

			try
			{
				var ticket = _ticketList.Find(t => t.Id == id);

				if (ticket == null)
				{
					logger.LogError("Ticket not found with Id: {Id}", id);
					return NotFound("Ticket not found");
				}
				_ticketList.Remove(ticket);
				logger.LogInformation("Item with specified Id has been successfully deleted");
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Cannot delete item");
			}
		} 
	}
	}
