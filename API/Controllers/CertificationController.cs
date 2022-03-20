using Application.DTOs.Certification;
using Application.Features.Certification.Request;
using Application.Features.Certification.Request.Commands;
using Application.Features.Certification.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CertificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<CertificationDto>>> Get(string id)
        {
            var certifications = await _mediator.Send(new GetCertificationListRequest { Id = id });
            return Ok(certifications);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<CertificationDto>> GetUserDetails(int id)
        {
            var certification = await _mediator.Send(new GetCertificationDetailsRequest() { Id = id });
            return Ok(certification);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(CreateCertificationDto certificationDto)
        {
            var command = new CreateCertificationCommande { createCertificationDto = certificationDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCertificationCommande { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] CertificationDto certificationDto)
        {
            var command = new UpdateCertificationCommande { certificationDto = certificationDto };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
