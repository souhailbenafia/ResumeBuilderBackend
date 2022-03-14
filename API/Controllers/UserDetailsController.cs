using Application.DTOs.User;
using Application.Features.User.Request.Commands;
using Application.Features.User.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var Users = await _mediator.Send(new GetUserListRequest());
            return Ok(Users);
        }

        // GET: api/<UserDetailsController>
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserDetails(int id)
        {
            var userDetail = await _mediator.Send(new GetUserDetailsCommand()); 
            return Ok(userDetail);
        }

        // Post: api/<CreateUserDetailsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> createUserDetails(CreateUserDetailDto createUserDetailDto)
        {
            var command = new CreateUserDetailsCommand { createUserDetailDto = createUserDetailDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
            



    }
}
