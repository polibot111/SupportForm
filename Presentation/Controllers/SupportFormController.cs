using DataAccess.Abstracts.Services;
using DataAccess.Consts;
using DataAccess.Request.SupportForm;
using DataAccess.Services;
using Infrastructure.CustomAttribute;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class SupportFormController : ControllerBase
    {
        private readonly ISupportFormService _supportFormService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SupportFormController(ISupportFormService supportFormService, IHttpContextAccessor httpContextAccessor)
        {
            _supportFormService = supportFormService;
            _httpContextAccessor = httpContextAccessor;
        }

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
            request.Username = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return Ok(await _supportFormService.AddForm(request));
        }
    }
}
