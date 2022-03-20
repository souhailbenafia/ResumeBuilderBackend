using Application.DTOs.SocialNetwork;
using Application.Features.SocialNetwork.Request.Commands;
using Application.Features.SocialNetwork.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkController : Controller
    {

        private readonly IMediator _mediator;
        public SocialNetworkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<SocialNetworkDto>>> Get(string id)
        {
            var certifications = await _mediator.Send(new GetSocialNetworkListRequest { Id = id });
            return Ok(certifications);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<SocialNetworkDto>> GetUserDetails(int id)
        {
            var certification = await _mediator.Send(new GetSocialNetworkDetailRequest() { Id = id });
            return Ok(certification);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(SocialNetworkDto socialDto)
        {
            var command = new CreateSocialNetworkCommand { SocialNetworkDto = socialDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteSocialNetworkCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] SocialNetworkDto soucialDto)
        {
            var command = new UpdateSocialNetworkCommand { SocialNetworkDto = soucialDto };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
