using DataAccess.Abstracts.Services;
using DataAccess.Consts;
using DataAccess.Services;
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
    public class FormStatusController : ControllerBase
    {
        public FormStatusController(IFormStatusService formStatusService)
        {
            _formStatusService = formStatusService;
        }
        readonly IFormStatusService _formStatusService;

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.FormStatus, ActionType = ActionType.ReadingAll,
        Definition = "Get FormStatus")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _formStatusService.GetAll());
        }
    }
}
