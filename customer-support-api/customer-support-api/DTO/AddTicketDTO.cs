namespace customer_support_api.DTO
{
    public class AddTicketDTO
    {
		public string? Id { get; set; }

		public string? Subject { get; set; }

		public string? Description { get; set; }

		public Enum? Status { get; set; }
	}
}
