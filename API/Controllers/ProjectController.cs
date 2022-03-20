using Application.DTOs.Project;
using Application.Features.LeaveTypes.Requests.Commands;
using Application.Features.LeaveTypes.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getbyuser")]
        public async Task<ActionResult<List<ProjectDto>>> Get(string id)
        {
            var projects = await _mediator.Send(new GetProjectListRequest { Id = id });
            return Ok(projects);
        }

        // GET: api/<UserDetailsController>
        [HttpGet("get")]
        public async Task<ActionResult<ProjectDto>> GetUserDetails(int id)
        {
            var project = await _mediator.Send(new GetProjectDetailRequest() { Id = id });
            return Ok(project);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost("add")]
        public async Task<ActionResult<BaseCommandResponse>> createCertification(ProjectDto projectDto)
        {
            var command = new CreateProjectCommand { projectDto = projectDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> Put([FromBody] ProjectDto projectDto)
        {
            var command = new UpdateProjectCommand { projectDto = projectDto };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
