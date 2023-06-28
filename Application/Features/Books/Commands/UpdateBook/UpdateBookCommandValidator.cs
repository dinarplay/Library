using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.Book.Title).Length(5, 50).NotEmpty();
            RuleFor(c => c.Book.Description).Length(5, 50).NotEmpty();
            RuleFor(c => c.Book.Count).GreaterThan(0).NotEmpty();
        }
    }
}
