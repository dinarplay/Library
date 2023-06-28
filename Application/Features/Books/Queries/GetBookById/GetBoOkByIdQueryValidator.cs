using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries.GetBookById
{
    public class GetBoOkByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBoOkByIdQueryValidator()
        {            
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
