using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Kemel.DAL.Configurations
{
    public class EntityMapping<T> : ClassMapping<T> where T : Entity.Entity
    {
        public EntityMapping()
        {
            Id(x => x.Id, map => map.Generator(Generators.Identity));
        }
    }
}
