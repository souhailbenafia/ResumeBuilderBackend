using Application.Features.Interest.Request.Commands;
using Application.Features.Interest.Request.Queries;
using Application.Responses;
using HR.LeaveManagement.Application.DTOs.Interest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InterestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<InterestDto>>> Get(string id)
        {
            var interests = await _mediator.Send(new GetInterestListRequest { Id = id });
            return Ok(interests);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<InterestDto>> GetUserDetails(int id)
        {
            var interest = await _mediator.Send(new GetInterestDetailRequest() { Id = id });
            return Ok(interest);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(InterestDto interestDto)
        {
            var command = new CreateInterestCommand { interestDto = interestDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteInterestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] InterestDto interestDto)
        {
            var command = new UpdateInterestCommand { interestDto = interestDto };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
