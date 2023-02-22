using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Application.Validation.Users;
using BulungurAcademy.Domain.Exceptions;
using FluentValidation.Results;
using System.Text;

namespace BulungurAcademy.Application.Services.Users;
public partial class UserService
{
    public void ValidationUserId(Guid userId)
    {
        if (userId == default)
        {
            throw new ValidationException($"The given userId is invalid: {userId}");
        }
    }
    public void ValidationTelegramId(long telegramId)
    {
        if (telegramId == default)
        {
            throw new ValidationException($"Cannot be null is teledramId that: {telegramId}");
        }
    }
    public void ValidationStorageUser(Domain.Entities.Users.User storageUser, Guid userId)
    {
        if (storageUser == null)
        {
            throw new NotFoundException($"Couldn't find user with given id: {userId}");
        }
    }
    public void ValidationStorageUserWithTelegramId(Domain.Entities.Users.User storageUser, long telegramId)
    {
        if (storageUser == null)
        {
            throw new NotFoundException($"Couldn't find user with given telegramId that: {telegramId}");
        }
    }
    public void ValidationUserForCreationDto(UserForCreaterDto userForCreaterDto)
    {
        ValidationResult validationResult =
            new UserForCreaterValidator().Validate(userForCreaterDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult: validationResult);
    }
    public void ValidationUserForModificationDto(UserForModificationDto userForModificationDto)
    {
        ValidationResult validationResult = 
            new UserModifictionValidator().Validate(userForModificationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult: validationResult);
    }
    private static void ThrowValidationExceptionIfValidationIsInvalid(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            StringBuilder messages = new();

            validationResult.Errors
                .ForEach(validation =>
                {
                    messages.Append("\n" + validation.ErrorMessage);
                });

            throw new ValidationException(messages.ToString());
        }
    }
}
