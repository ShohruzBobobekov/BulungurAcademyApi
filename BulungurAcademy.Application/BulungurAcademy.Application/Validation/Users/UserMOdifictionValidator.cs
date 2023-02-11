using BulungurAcademy.Application.DataTranferObjects.Users;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BulungurAcademy.Application.Validation.Users;


public class UserModifictionValidator : AbstractValidator<UserForModificationDto>
{
	public UserModifictionValidator()
	{
        RuleFor(user => user)
            .NotEmpty();

        RuleFor(user => user.phoneNumber)
            .Matches(new Regex("^\\+?[1-9][0-9]{7,14}$"))
            .WithMessage("PhoneNumber not valid");
    }
}
