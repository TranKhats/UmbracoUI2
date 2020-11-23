using Autofac;
using IServices.IServices;
using Module = Autofac.Module;

namespace UmbracoUI2.Services
{
    public class RegisteredServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SearchingService>().As<ISearchService>().AsSelf();
            builder.RegisterType<NavigationService>().As<INavigationService>().AsSelf();
            builder.RegisterType<ShareableContentService>().As<IShareableContentService>().AsSelf();
            base.Load(builder);
        }
    }
}