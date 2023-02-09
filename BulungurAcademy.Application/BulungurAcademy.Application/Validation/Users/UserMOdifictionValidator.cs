using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Domain.Entities.Users;
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
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            .WithMessage("PhoneNumber not valid");
    }
}
