using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Web.Core.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RefreshJWTokenController : ApplicationControllerBase    
    {
        private readonly IJwtTokenFactory _jwtTokenFactory;

        public RefreshJWTokenController(
            IJwtTokenFactory jwtTokenFactory)
        {
            _jwtTokenFactory = jwtTokenFactory;
        }

        [HttpPost]
        public ActionResult<ClaimsIdentity> Post([FromBody]string token)
        {
            var jwtToken = _jwtTokenFactory.Refresh(token);
            return Created(Request.Path, jwtToken);
        }

        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "I'm alive!";
        }
    }
}
