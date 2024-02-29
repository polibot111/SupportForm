using DataAccess.Abstracts.Services;
using DataAccess.Consts;
using DataAccess.Request.SupportForm;
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
    public class SupportFormController : ControllerBase
    {
        public SupportFormController(ISupportFormService supportFormService)
        {
            _supportFormService = supportFormService;
        }
        readonly ISupportFormService _supportFormService;

        [HttpGet]
        public async Task<IActionResult> GetForms()
        {

           return Ok(await _supportFormService.GetAllForms());

        }

        [HttpPost("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinitionConstants.SupportForm, ActionType = ActionType.Writing,
            Definition = "Create Support Form")]
        public async Task<IActionResult> CreateForm([FromBody] SupportFormInsertCommand request)
        {
            return Ok(await _supportFormService.AddForm(request));
        }

    }
}
