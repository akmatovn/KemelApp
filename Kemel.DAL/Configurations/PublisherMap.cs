using Kemel.DAL.Entity;

namespace Kemel.DAL.Configurations
{
    public class PublisherMap : EntityMapping<Publisher>
    {
        public PublisherMap()
        {
            Table("Publishers");

            Property(x => x.Name, map =>
            {
                map.NotNullable(true);
                map.Unique(true);
                map.Length(50);
            });

            Bag(x => x.Books,
                c =>
                {
                    c.Key(k => k.Column("PublisherId"));
                    c.Inverse(true);
                },
                r => r.OneToMany());
        }
    }
}
