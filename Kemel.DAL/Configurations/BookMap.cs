using System;
using Kemel.DAL.Entity;
using NHibernate.Mapping.ByCode;

namespace Kemel.DAL.Configurations
{
    public class BookMap : EntityMapping<Book>
    {
        public BookMap()
        {
            Table("Books");

            Property(x => x.Name, map=>
            {
                map.NotNullable(true);
                map.Unique(true);
                map.Length(50);
            });
            Property(x => x.Description, map=>map.Length(Int32.MaxValue));
            Property(x => x.Price, map =>map.NotNullable(true));
            Property(x => x.PublishedAt, map=>map.NotNullable(true));

            Set(a => a.Authors,
                c =>
                {
                    c.Cascade(Cascade.Persist);
                    c.Key(k => k.Column("BookId"));
                    c.Table("BooksToAuthors");
                },
                r => r.ManyToMany(m => m.Column("AuthorId"))
                );

            ManyToOne(x => x.Publisher,
                c =>
                {
                    c.Cascade(Cascade.Persist);
                    c.Column("PublisherId");
                    c.NotNullable(true);
                });
        }
    }
}
