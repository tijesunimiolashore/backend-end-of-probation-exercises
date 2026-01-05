namespace customer_support_api.Models
{
    public class Ticket
    {
		public Ticket(string id, string subject, string description, Enum status)
		{
			Id = id;
			Subject = subject;
			Description = description;
			CreatedAt = DateTime.UtcNow;
			Status = status;
		}

		public string Id { get; set; }

		public string Subject { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public Enum Status { get; set; }
	}
}
