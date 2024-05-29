using SimpleInjector;
using System.Reflection;
using System.Web.Mvc;
using BackNewVersion;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace WebApplication1.App_Start
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            container.Register<AppDBContext>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}