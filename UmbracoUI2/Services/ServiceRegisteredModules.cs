using Autofac;
using IServices.IServices;
using Module = Autofac.Module;

namespace UmbracoUI2.Services
{
    public class ServiceRegisteredModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SearchingService>().As<ISearchService>().AsSelf();
            builder.RegisterType<NavigationService>().As<INavigationService>().AsSelf();
            base.Load(builder);
        }
    }
}