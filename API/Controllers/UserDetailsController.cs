using Application.DTOs.User;
using Application.Features.User.Request.Commands;
using Application.Features.User.Request.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [HttpGet("get")]
        public async Task<ActionResult<UserDto>> GetUserDetails(string id)
        {
            var userDetail = await _mediator.Send(new GetUserDetailsCommand() { Id = id }); 
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

        [HttpGet("getAll")]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] UserParameters usrerParameters)
        {
            
            var Users = await _mediator.Send(new GetAllRequest(){ UserParameters = usrerParameters });

            var metadata = new
            {
                Users.TotalCount,
                Users.PageSize,
                Users.CurrentPage,
                Users.TotalPages,
                Users.HasNext,
                Users.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(Users);

          
        }

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<List<DevDto>>> GetUsers()
        {
            var userDetail = await _mediator.Send(new GetRequest());
            return Ok(userDetail);
        }





    }
}
