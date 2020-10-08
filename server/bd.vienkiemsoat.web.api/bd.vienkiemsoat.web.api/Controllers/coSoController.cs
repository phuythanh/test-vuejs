using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using bd.vienkiemsoat.web.service.Interfaces;

namespace bd.vienkiemsoat.web.api.Controllers
{
    public class CoSoController : BaseController
    {
        private readonly ICosoService _cosoService;

        public CoSoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IMapper mapper, ICosoService cosoService) : base(userManager, mapper, signInManager)
        {
            _cosoService = cosoService;
        }


        // GET api/values
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _cosoService.GetAll();
            return Ok(result);
        }

       
    }
}
