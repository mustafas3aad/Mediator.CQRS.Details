using Mediator.CQRS.Models;
using MediatR;

namespace Mediator.CQRS.Queries
{
    public class GetUserByIndex:IRequest<UserModel>
    {
        public int Index { get; set; }
        public GetUserByIndex(int index)
        {
            Index = index;

        }
    }
}
