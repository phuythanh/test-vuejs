using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using bd.vienkiemsoat.web.data;
using CommonServiceLocator;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace bd.vienkiemsoat.web.api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private  ApplicationSignInManager _applicationSignInManager;
        private  ApplicationUserManager _applicationUserManager;

        public ApplicationOAuthProvider() {
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            _applicationSignInManager = context.OwinContext.GetUserManager<ApplicationSignInManager>();
            _applicationUserManager = context.OwinContext.Get<ApplicationUserManager>();
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var dbcontext = ServiceLocator.Current.GetInstance<ApplicationIdentityContext>();
            var result = await _applicationSignInManager.PasswordSignInAsync(context.UserName, context.Password,false,true);
            if (result == SignInStatus.Success )
            {
                var user = await _applicationUserManager.FindByNameAsync(context.UserName);
                if (!user.IsActive) {
                    context.Rejected();
                    context.SetError("Lỗi đăng nhập", "Tài khoản không tồn tại.");
                    return;
                }
                var roles = _applicationUserManager.GetRoles(user.Id);
                //identity.AddClaim(new Claim(ClaimTypes.Role, String.Join(";", user.Roles.Select(x => x.RoleId).ToArray())));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                
                foreach (var role in roles)
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));

                var data = new Dictionary<string, string>
                {
                    { "userName", user.UserName },
                    { "roles", string.Join(",", user.Roles)}
                };
                var properties = new AuthenticationProperties(data);


                var ticket = new AuthenticationTicket(identity, properties);
                context.Validated(ticket);
            }
            else
            {
                context.Rejected();
                if (result == SignInStatus.Failure) {
                    context.SetError("Lỗi đăng nhập", "Tài khoản hoặc mật khẩu không chính xác. ");
                }
                if (result == SignInStatus.LockedOut)
                {
                    context.SetError("Khóa tài khoản", "Tài khoản của bạn đã bị khóa, đợi 15 phút để mở lại");
                }

                if (result == SignInStatus.RequiresVerification)
                {
                    context.SetError("Chưa xác minh tài khoản", "Tài khoản của bạn chưa được xác nhận bởi email hay Admin");
                }              

            }
        }
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            return base.GrantRefreshToken(context);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            return base.TokenEndpoint(context);
        }
    }
    
}