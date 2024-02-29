using DataAccess.Abstracts.Services;
using DataAccess.Consts;
using DataAccess.Request.Role;
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
    public class RoleController : ControllerBase
    {
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        readonly IRoleService _roleService;

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.Role, ActionType = ActionType.ReadingAll,
            Definition = "Get Roles")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAllRoles());
        }
        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.Role, ActionType = ActionType.Writing,
            Definition = "Create Role")]
        public async Task<IActionResult> Add([FromBody] RoleInsertCommand request)
        {
            return Ok(await _roleService.CreateRoleAsync(request));
        }
        [HttpDelete]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.Role, ActionType = ActionType.Deleting,
            Definition = "Delete Role")]
        public async Task<IActionResult> Delete([FromBody] RoleDeleteCommand request)
        {
            return Ok(await _roleService.DeleteRoleAsync(request));
        }
    }
}
