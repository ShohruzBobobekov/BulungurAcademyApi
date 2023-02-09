using FluentValidation;
using Telegram.Bot.Types;

namespace BulungurAcademy.Application.Validation.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty();
    }
}
