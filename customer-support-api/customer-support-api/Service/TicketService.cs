using customer_support_api.Enums;
using customer_support_api.Models;

namespace customer_support_api.Service
{
	public class TicketService
	{
		public TicketService()
		{
			var _ticket = new Ticket("1", "Maiden 1", "A Ticket to the Mall", (Status)2);
		}
	}
}
