using BulungurAcademy.Application.DataTranferObjects.Users;
using FluentValidation;
using System.Text.RegularExpressions;

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

        RuleFor(user => user.phoneNumber)
            .Matches(new Regex("^\\+?[1-9][0-9]{7,14}$"))
            .WithMessage("PhoneNumber not valid");
    }
}
