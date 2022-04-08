using Application.DTOs.Info;
using Application.Features.Info.Request.Commands;
using Application.Features.Info.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<InfoDto>>> Get(string id)
        {
            var certifications = await _mediator.Send(new GetInfoListRequest { Id = id });
            return Ok(certifications);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<InfoDto>> GetUserDetails(int id)
        {
            var certification = await _mediator.Send(new GetInfoDetailRequest() { Id = id });
            return Ok(certification);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(InfoDto certificationDto)
        {
            var command = new CreateInfoCommand { infoDto = certificationDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteInfoCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] InfoDto certificationDto)
        {
            var command = new UpdateInfoCommand{ infoDto = certificationDto };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
