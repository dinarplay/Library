using FluentValidation;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(c => c.User.Email).Length(5, 50).EmailAddress().NotEmpty();
            RuleFor(c => c.User.Name).Length(5, 50).NotEmpty();
            RuleFor(c => c.User.Password).Length(5, 30).NotEmpty();
            RuleFor(c => c.User.RoleId).InclusiveBetween(1,3).NotEmpty();
        }
    }
}
