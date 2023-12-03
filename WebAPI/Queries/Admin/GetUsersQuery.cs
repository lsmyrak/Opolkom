using MediatR;

namespace WebAPI.Queries
{
    public class GetUsersQuery:IRequest<IEnumerable<string>>
    {
        public GetUsersQuery()
        {
            
        }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
