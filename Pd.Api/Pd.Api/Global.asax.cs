using Autofac;
using Autofac.Integration.Mvc;
using IServices.Infrastructure;
using IServices.ISysServices;
using Pd.Api.Helper;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pd.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer<Services.ApplicationDb>(null);



            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load("Services"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();

            builder.RegisterType<UserInfo>().As<IUserInfo>();

          

         

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            

            var container = builder.Build();

            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));




            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
