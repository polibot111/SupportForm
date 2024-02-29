using DataAccess.Abstracts.Services;
using DataAccess.Consts;
using DataAccess.Request.User;
using Infrastructure.CustomAttribute;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        readonly IUserService _userService;

        [HttpGet("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.ReadingAll,
            Definition = "Get All Admins")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetAdmins()
        {
            return Ok(await _userService.GetAllAdmins());
        }

        [HttpGet("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.ReadingAll,
            Definition = "Get All Members")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetMembers()
        {
            return Ok(await _userService.GetAllMembers());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] UserInsertCommand request)
        {
            return Ok(await _userService.CreateUser(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] UserCommandForPassword request)
        {
            return Ok(await _userService.UpdatePassword(request));
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.Updating,
            Definition = "Update User Role")]
        public async Task<IActionResult> UserRoleUpdate([FromBody] UserCommandForUserRole request)
        {
            return Ok(await _userService.UpdateUserRole(request));
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.Deleting,
            Definition = "Delete User")]
        public async Task<IActionResult> DeleteUser([FromBody] UserDeleteCommand request)
        {
            return Ok(await _userService.DeleteUser(request));
        }
    }
}
