using System.Web.Mvc;
using Kemel.BLL;
using Kemel.BLL.Interfaces;
using Kemel.BLL.ServiceHost;
using Kemel.BLL.Services;
using Kemel.WEB.Controllers;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace Kemel.WEB
{
    public static class UnityConfig
    {
        public static UnityContainer Container { get; set; }
        public static IServiceHost ServiceHost { get; set; }

        static UnityConfig()
        {
            RegisterComponents();
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            ConfigDI(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            Container = container;
            ServiceHost = container.Resolve<IServiceHost>();
        }

        private static void ConfigDI(UnityContainer container)
        {
            ConfigureDI.Config(container);
            container
                .RegisterType<IServiceHost, ServiceHost>(new InjectionConstructor(container))
                .RegisterType<IController, Controller>()
                .RegisterType<IAuthorService, AuthorService>()
                .RegisterType<IPublisherService, PublisherService>()
                .RegisterType<IBookService, BookService>();
        }
    }
}