using Kemel.BLL.Interfaces;

namespace Kemel.BLL.ServiceHost
{
    public interface IServiceHost
    {
        void Register<T>(T service) where T : IService;
        T GetService<T>() where T : IService;
    }
}
