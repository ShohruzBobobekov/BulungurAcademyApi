using BulungurAcademy.Domain.Entities.Users;
using FluentValidation;

namespace BulungurAcademy.Application.Validation.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty();
        RuleFor(user => user.Id)
            .NotNull();
    }
}
