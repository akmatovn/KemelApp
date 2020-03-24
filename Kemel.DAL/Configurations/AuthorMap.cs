using Kemel.DAL.Entity;
using NHibernate.Mapping.ByCode;

namespace Kemel.DAL.Configurations
{
    public class AuthorMap : EntityMapping<Author>
    {
        public AuthorMap()
        {
            Table("Authors");

            Property(x => x.Name, map =>
            {
                map.NotNullable(true);
                map.Unique(true);
                map.Length(50);
            });

            Set(a => a.Books,
                c =>
                {
                    c.Cascade(Cascade.All);
                    c.Key(k => k.Column("AuthorId"));
                    c.Table("BooksToAuthors");
                    c.Inverse(true);
                },
                r => r.ManyToMany(m => m.Column("BookId")));
        }
    }
}
