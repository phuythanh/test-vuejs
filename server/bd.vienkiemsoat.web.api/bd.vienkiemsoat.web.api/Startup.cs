using Autofac;
using bd.vienkiemsoat.web.api.Providers;
using bd.vienkiemsoat.web.data;
using CommonServiceLocator;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(bd.vienkiemsoat.web.api.Startup))]

namespace bd.vienkiemsoat.web.api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var config = GlobalConfiguration.Configuration;
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            DependenciesInjection.RegisterDI(config, app);
            
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/Token"),

                //Resolve the interface here
                Provider = new ApplicationOAuthProvider(),

                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true,
               // RefreshTokenProvider = new ApplicationRefreshTokenProvider()
            };
            ConfigureAuth(app);
            
        }
    }
}
