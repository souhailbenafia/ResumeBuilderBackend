using Application.DTOs.Language;
using Application.DTOs.Skill;
using Application.Features.Skill.Request.Commands;
using Application.Features.Skill.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class skillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public skillController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<SkillDto>>> Get(string id)
        {
            var skills = await _mediator.Send(new GetSkillListRequest { Id = id });
            return Ok(skills);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<SkillDto>> GetUserDetails(int id)
        {
            var skill = await _mediator.Send(new GetSkillDetailRequest() { Id = id });
            return Ok(skill);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(SkillDto skillDto)
        {
            var command = new CreateSkillCommand { skillDto = skillDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteSKillCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] SkillDto skillDto)
        {
            var command = new UpdateSKillCommand { skillDto = skillDto };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
