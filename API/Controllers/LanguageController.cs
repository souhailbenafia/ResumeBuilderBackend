using Application.DTOs.Language;
using Application.Features.Language.Request.Commands;
using Application.Features.Language.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly IMediator _mediator;

        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<LanguageDto>>> Get(string id)
        {
            var languages = await _mediator.Send(new GetLanguageListRequest { Id = id });
            return Ok(languages);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<LanguageDto>> GetUserDetails(int id)
        {
            var language = await _mediator.Send(new GetLanguageDetailRequest() { Id = id });
            return Ok(language);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(LanguageDto languageDto)
        {
            var command = new CreateLanguageCommand { language = languageDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLanguageCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] LanguageDto languageDto)
        {
            var command = new UpdateLanguageCommand { languageDto = languageDto };
            await _mediator.Send(command);
            return NoContent();
        }


    }

}
