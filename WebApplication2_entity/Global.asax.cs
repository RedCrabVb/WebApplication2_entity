using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using WebApplication2_entity.Service;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Data;

namespace WebApplication2_entity
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var config = GlobalConfiguration.Configuration;

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<Class1Service>()
                .As<IClass1Service>()
                .InstancePerLifetimeScope();


            //var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection1"].ConnectionString;

            var connectionString = ConfigurationManager.AppSettings["defaultConnection2"];


            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            builder.RegisterType<AppDbContext>()
                .WithParameter("options", optionsBuilder.Options)
                .InstancePerLifetimeScope();


            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
