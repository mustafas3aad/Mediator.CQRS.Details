using Mediator.CQRS.Commands;
using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using Mediator.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.CQRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly IUserServices _userServices;
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
           //return  _userServices.GetUsers();
           var query = new GetUsersQuery();
           var result = await _mediator.Send(query);
           return Ok(result);
        }
        [HttpGet("{index}")]
        public async Task<ActionResult<UserModel>> GetUserByIndex(int index)
        {
            var query = new GetUserByIndex(index);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel user)
        {
            var command = new AddUserCommand(user.Id, user.FirstName, user.LastName);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
