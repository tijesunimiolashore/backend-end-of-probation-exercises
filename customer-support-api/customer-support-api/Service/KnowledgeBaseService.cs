using customer_support_api.Models;

namespace customer_support_api.Service
{
    public class KnowledgeBaseService
    {
		public KnowledgeBaseService()
		{
			var _knowledgebase = new KnowledgeBaseArticle("1", "Maiden 1", "A Ticket to the Mall", "Samuel", ("111", "222"));
		}
	}
}
