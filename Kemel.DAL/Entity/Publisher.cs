using System.Collections.Generic;

namespace Kemel.DAL.Entity
{
    public class Publisher : Entity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new HashSet<Book>();
        }
    }
}
