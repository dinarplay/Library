using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Queries.GetAllPublishers
{
    internal class GetAllPublishersQueryHandler : IRequestHandler<GetAllPublishersQuery, List<Publisher>>
    {
        private readonly IAppDbContext context;

        public GetAllPublishersQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }

        async public Task<List<Publisher>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            var publishers = await context.Publishers.ToListAsync();
            return publishers;
        }
    }
}
