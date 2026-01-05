using System.Collections.Generic;

namespace customer_support_api.Models
{
    public class KnowledgeBaseArticle
    {
        public KnowledgeBaseArticle(string? id, string? title, string? content, string? author, (string, string) tags)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
            Tags = tags;
        }

        public string? Id { get; set; }

		public string? Title { get; set; }

		public string? Content { get; set; }

		public string? Author { get; set; }

		public (string, string)? Tags { get; set; }
    }
}
