using Mediator.CQRS.Commands;
using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using MediatR;

namespace Mediator.CQRS.Handlers.CommandHandler
{
    // Note:
    // This is ( Next )
    public class UserCommandHandler : IRequestHandler<AddUserCommand,UserModel>
    {
        private readonly IUserServices _userServices;
        public UserCommandHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<UserModel> Handle(AddUserCommand request,CancellationToken cancellationToken)
        {
            // Note:
            // Call Logic

            var user = new UserModel
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            return await Task.FromResult(_userServices.AddUser(user));
        }
    }
}
