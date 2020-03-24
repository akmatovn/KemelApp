using System;
using System.Collections.Generic;

namespace Kemel.DAL.Entity
{
    public class Book : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int PublisherId { get; set; }
        public virtual decimal Price { get; set; }
        public virtual DateTime PublishedAt { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual Publisher Publisher { get; set; }

        public Book()
        {
            Authors = new HashSet<Author>();
        }
    }
}
