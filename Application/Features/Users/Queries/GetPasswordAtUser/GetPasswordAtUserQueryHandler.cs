using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetPasswordAtUser
{
    internal class GetPasswordAtUserQueryHandler : IRequestHandler<GetPasswordAtUserQuery, string>
    {
        private readonly IAppDbContext context;

        public GetPasswordAtUserQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<string> Handle(GetPasswordAtUserQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstAsync(x => x.Id == request.User.Id, cancellationToken);
            return user.Password;
        }
    }
}
