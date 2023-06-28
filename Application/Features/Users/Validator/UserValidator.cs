using Domain;
using FluentValidation;

namespace Application.Features.Users.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Email).Length(5, 50).EmailAddress().NotEmpty();
            RuleFor(c => c.Name).Length(5, 50).NotEmpty();
            RuleFor(c => c.Password).Length(5, 30).NotEmpty();
            RuleFor(c => c.RoleId).InclusiveBetween(1, 3).NotEmpty();
        }
    }
}
