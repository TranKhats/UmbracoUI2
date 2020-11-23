using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using IServices.IServices;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;
using UmbracoUI2.Services;

namespace UmbracoDI2
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ViewRegistrationSource());


            // register all controllers found in your assembly
            builder.RegisterControllers(typeof(Startup).Assembly);
            builder.RegisterApiControllers(typeof(Startup).Assembly);

            // register Umbraco MVC + web API controllers used by the admin site
            builder.RegisterControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            // add custom class to the container as Transient instance
            builder.RegisterType<MyAwesomeContext>();
            builder.RegisterModule(new RegisteredServiceModules());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            RegisterCustomRoutes();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            base.ApplicationStarting(umbracoApplication, applicationContext);
        }


        private static void RegisterCustomRoutes()
        {
            RouteTable.Routes.MapRoute(
               name: "FormsController",
               url: "Forms/{action}/{id}",
               defaults: new { controller = "Forms", action = "Index", id = UrlParameter.Optional });
            RouteTable.Routes.MapRoute(
               name: "NavigationController",
               url: "Navigation/{action}/{id}",
               defaults: new { controller = "Navigation", action = "Index", id = UrlParameter.Optional });
        }
    }
    public class MyAwesomeContext
    {
        public MyAwesomeContext()
        {
            MyId = Guid.NewGuid();
        }
        public Guid MyId { get; private set; }
    }

}