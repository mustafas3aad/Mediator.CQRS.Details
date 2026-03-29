using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using Mediator.CQRS.Queries;
using MediatR;

namespace Mediator.CQRS.Handlers.QueriesHandler
{
    // Note:
    // This is ( Next )
    public class UsersQueryHandler : IRequestHandler<GetUsersQuery,List<UserModel>>,
                                        IRequestHandler<GetUserByIndex,UserModel>
    {
        private readonly IUserServices _userServices;
        public UsersQueryHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<List<UserModel>> Handle(GetUsersQuery request,CancellationToken cancellationToken)
        {
            // Note:
            // Call Logic
            return await Task.FromResult(_userServices.GetUsers());
        }

        public async Task<UserModel> Handle(GetUserByIndex request,CancellationToken cancellationToken)
        {
            return await Task.FromResult(_userServices.GetUserByIndex(request.Index));
        }
    }
}
