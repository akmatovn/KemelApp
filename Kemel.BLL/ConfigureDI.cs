using Kemel.DAL.Repository;
using Unity;

namespace Kemel.BLL
{
    public class ConfigureDI
    {
        public static void Config(IUnityContainer container)
        {
            container
                .RegisterType<IRepository, RepositoryBase>();
        }
    }
}
