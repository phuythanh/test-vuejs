

using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using bd.vienkiemsoat.web.data;
using CommonServiceLocator;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace bd.vienkiemsoat.web.api
{
    public static class DependenciesInjection
    {
        public static void RegisterDI(HttpConfiguration config, IAppBuilder app) {
            // Register dependencies, then...            
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterModule(new service.ServiceModule(connStr));
            var x = new ApplicationIdentityContext(connStr);
            builder.Register(c => x);
            //builder.Register(c => new UserStore<ApplicationUser>(x)).AsImplementedInterfaces();
            builder.RegisterType<UserStore<ApplicationUser, ApplicationRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>>().As<IUserStore<ApplicationUser,Guid>>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName"),
            });
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>().AsImplementedInterfaces(); ;
            builder.RegisterType<UserManager<ApplicationUser,Guid>>();
            builder.RegisterType<SignInManager<ApplicationUser, Guid>>();
            builder.RegisterType<ApplicationUserManager>();
            builder.RegisterType<ApplicationSignInManager>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }
    }
}
