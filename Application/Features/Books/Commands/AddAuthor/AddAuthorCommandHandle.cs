using Application.Interfaces;
using MediatR;

namespace Application.Features.Books.Commands.AddAuthor
{
    public class AddAuthorCommandHandle : IRequestHandler<AddAuthorCommand, int>
    {
        private readonly IAppDbContext context;
        public AddAuthorCommandHandle(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }
        async public Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = request.Author;
            await context.Authors.AddAsync(author, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return author.Id;
        }
    }
}
