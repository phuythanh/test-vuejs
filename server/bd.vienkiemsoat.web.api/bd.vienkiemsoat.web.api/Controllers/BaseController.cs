using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using AutoMapper;
using bd.vienkiemsoat.web.data;
using Microsoft.AspNet.Identity;

namespace bd.vienkiemsoat.web.api.Controllers
{
    //[Authorize]
    public class BaseController : ApiController
    {
        private ApplicationUser _UserInfo;
        protected readonly IMapper _mapper;
        protected readonly ApplicationUserManager _userManager = null;
        protected readonly ApplicationSignInManager _signInManager;
        public BaseController(ApplicationUserManager userManager, IMapper mapper, ApplicationSignInManager signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public List<Claim> UserClaims  => new ClaimsPrincipal(User).Claims.ToList();

        protected ApplicationUser UserInfo
        {
            get
            {
                if (_UserInfo != null)
                {
                    return _UserInfo;
                }
                var userId = UserClaims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Sid))?.Value;

                if (userId == null)
                {
                    return null;
                }

                _UserInfo = _userManager.FindByIdAsync(new Guid(userId)).Result;

                return _UserInfo;
            }
        }

        protected bool IsTinh
        {
            get
            {
                var roleName = UserClaims.Where(x => x.Type.Equals(ClaimTypes.Role)).Select(x => x.Value).ToList();
                return roleName.Any(x => x.Equals("Tỉnh") || x.Equals("b168fee3-865a-4aab-8d4c-9e40e4949ca6"));
            }
        }

        protected Guid UserId => new Guid(UserClaims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Sid))?.Value);

    }
}
