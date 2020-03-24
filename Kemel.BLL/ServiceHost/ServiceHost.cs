using System;
using System.Collections.Generic;
using Kemel.BLL.Interfaces;
using Unity;

namespace Kemel.BLL.ServiceHost
{
    public class ServiceHost : IServiceHost
    {
        private readonly IUnityContainer _container;
        private readonly Dictionary<Type, IService> _service;

        public ServiceHost(IUnityContainer container)
        {
            _container = container;
            _service = new Dictionary<Type, IService>();
        }

        public void Register<T>(T service) where T : IService
        {
            if (!_service.ContainsKey(typeof(T)))
                _service.Add(typeof(T), service);
        }

        public T GetService<T>() where T : IService
        {
            var service = _container.Resolve<T>();
            return service;
        }
    }
}
