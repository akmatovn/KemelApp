using System.Collections.Generic;

namespace Kemel.DAL.Entity
{
    public class Author : Entity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new HashSet<Book>();
        }
    }
}
