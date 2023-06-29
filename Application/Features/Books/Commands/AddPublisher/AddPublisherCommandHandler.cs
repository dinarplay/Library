using Application.Interfaces;
using MediatR;

namespace Application.Features.Books.Commands.AddPublisher
{
    internal class AddPublisherCommandHandler : IRequestHandler<AddPublisherCommand, int>
    {
        private readonly IAppDbContext context;

        public AddPublisherCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }

        async public Task<int> Handle(AddPublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = request.Publisher;
            await context.Publishers.AddAsync(publisher, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return publisher.Id;
        }
    }
}
