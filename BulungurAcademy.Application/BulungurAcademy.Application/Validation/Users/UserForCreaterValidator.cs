using BulungurAcademy.Application.DataTranferObjects.Users;
using FluentValidation;

namespace BulungurAcademy.Application.Validation.Users;

public class UserForCreaterValidator : AbstractValidator<UserForCreaterDto>
{
	public UserForCreaterValidator()
	{
        RuleFor(user => user)
            .NotNull();

        RuleFor(user => user.firstName)
            .MaximumLength(100)
            .NotEmpty();
    }
}
