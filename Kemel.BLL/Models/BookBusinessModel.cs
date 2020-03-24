using System;
using System.Collections;
using System.Collections.Generic;

namespace Kemel.BLL.Models
{
    public class BookBusinessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedAt { get; set; }
        public string AuthorName { get; set; }
        public virtual List<int> Authors { get; set; }
        public virtual PublisherBusinessModel Publisher { get; set; }

        public BookBusinessModel()
        {
            Authors = new List<int>();
        }
    }
}
