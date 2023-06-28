using Domain;
using FluentValidation;

namespace Application.Features.Books.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(c => c.Title).Length(5, 50).NotEmpty();
            RuleFor(c => c.Description).Length(5, 100).NotEmpty();
            RuleFor(c => c.AuthorId).NotEmpty();
            RuleFor(c => c.PublisherId).NotEmpty();
            RuleFor(c => c.GenreId).NotEmpty();
            RuleFor(c => c.Count).GreaterThan(0).NotEmpty();
        }
    }
}
