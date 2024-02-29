using DataAccess.Consts;
using DataAccess.Request.AssignRoleEndpoint;
using Infrastructure.Abstracts;
using Infrastructure.CustomAttribute;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IAuthorizationEndpointService _service;

        public AuthorizationEndpointsController(IAuthorizationEndpointService service)
        {
            _service = service;
        }

        [HttpGet("{Id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.Authorization, ActionType = ActionType.ReadingAll,
            Definition = "Read Role Endpoints")]
        public async Task<IActionResult> GetEndpointsToRole([FromRoute] AssignedEndpointToRoleQuery request)
        {
            return Ok(await _service.GetEndpointAsync(request));
        }

        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.Authorization, ActionType = ActionType.Writing,
            Definition = "Assign Endpoint To Role")]
        public async Task<IActionResult> AssignEntpointRole([FromBody] AssignRoleEndpointInsertCommand request)
        {
            return Ok(await _service.AssignEndpointRoleAsync(request, typeof(Program)));
        }
    }
}
