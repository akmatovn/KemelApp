using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Kemel.DAL
{
    public static class Database
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {

                    var cfg = new Configuration()
                        .DataBaseIntegration(db =>
                        {
                            db.Driver<NHibernate.Driver.SqlClientDriver>();
                            db.Dialect<MsSql2012Dialect>();

                            db.ConnectionString =
                                @"Server=(local)\ERVER;Initial Catalog=BookShopDB;User ID=sa;Password=_;";
                        });
                    var mapper = new ModelMapper();
                    mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                    HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                    cfg.AddMapping(mapping);
                    new SchemaUpdate(cfg).Execute(true, true);
                    _sessionFactory = cfg.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
