using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Experience;
using Application.Features.Experience.Request.Queries;
using Application.Responses;
using Application.Features.Experience.Request.Commands;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExperianceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExperianceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<ExperienceDto>>> Get(string id)
        {
            var certifications = await _mediator.Send(new GetExperianceListRequest { Id = id });
            return Ok(certifications);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<ExperienceDto>> GetUserDetails(int id)
        {
            var certification = await _mediator.Send(new GetExperianceDetailRequest() { Id = id });
            return Ok(certification);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(ExperienceDto expirienceDto)
        {
            var command = new CreateExperianceCommand { experianceDto = expirienceDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteExperianceCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] ExperienceDto expDto)
        {
            var command = new UpdateExperianceCommand { experianceDto = expDto };
            await _mediator.Send(command);
            return NoContent();
        }
    }


}
