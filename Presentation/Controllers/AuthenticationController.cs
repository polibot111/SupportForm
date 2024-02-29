using Infrastructure.Abstracts;
using Infrastructure.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(ILoginOperations loginOperations)
        {
            _loginOperations = loginOperations;
        }

        readonly private ILoginOperations _loginOperations;

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Ok(await _loginOperations.Login(request));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] LoginWithRefreshTokenRequest request)
        {
            return Ok(await _loginOperations.RefreshTokenLogin(request));
        }
    }
}
