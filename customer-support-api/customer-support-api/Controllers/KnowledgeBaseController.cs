using customer_support_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customer_support_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KnowledgeBaseController : ControllerBase
	{
		private readonly List<KnowledgeBaseArticle> _knowledgeBase = new();
		private readonly ILogger logger;

		public KnowledgeBaseController(ILogger ilogger)
		{
			logger = ilogger;
		}

		[HttpPost]
		public IActionResult aaddArticle(Ticket myticket)
		{

			logger.LogInformation("Add a new article for Knowledge Base");
			try
			{
				var knowledgeBase = new KnowledgeBaseArticle("2", "Maiden", "A Mall Ticket", "Samuel", ("111", "222"));
				_knowledgeBase.Add(knowledgeBase);
				return Ok(knowledgeBase);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Cannot add article");
			}
		}

		[HttpGet]
		public IActionResult GetAllTicket()
		{
			logger.LogInformation("Get all Articles");
			try
			{
				_knowledgeBase.ToList();
				return Ok(_knowledgeBase);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Cannot add article");
			}
		}

		[HttpGet]
		public IActionResult Search(string title, string content)
		{
			logger.LogInformation("Search through Articles");
			try
			{
				var myvalue = _knowledgeBase.ToList().Where(x => x.Title == title && x.Content == content);
				return Ok(myvalue);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Cannot search article");
			}
		}
	}
		}
