using Application.DTOs.Education;
using Application.Features.Education.Request.Commands;
using Application.Features.Education.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EducationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EducationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<EducationDto>>> Get(string id)
        {
            var certifications = await _mediator.Send(new GetEducationListRequest { Id = id });
            return Ok(certifications);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<EducationDto>> GetUserDetails(int id)
        {
            var certification = await _mediator.Send(new GetEducationDetailRequest() { Id = id });
            return Ok(certification);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(EducationDto educationDto)
        {
            var command = new CreateEducationCommand { Educationdto = educationDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEducationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] EducationDto EducationDto)
        {
            var command = new UpdateEducationCommand { EducationDto = EducationDto };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
