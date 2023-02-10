using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Application.Validation.Users;
using BulungurAcademy.Domain.Entities.Users;
using BulungurAcademy.Infrastructure.Repositories.Users;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using Telegram.Bot.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BulungurAcademy.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;
    public UserService(IUserRepository userRepository,
        IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }
    public async ValueTask<UserDto> CreateUserAsync(UserForCreaterDto userForCreaterDto)
    {
        var validationResult = new UserForCreaterValidator().Validate(userForCreaterDto);
        if (validationResult.IsValid)
        {
            string message = "";
            validationResult.Errors
                .ForEach(validation => { message += "\n" + validation.ErrorMessage; });
            throw new Exception(message);
        }

        var newUser = this.userFactory
            .MapToUser(userForCreaterDto);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return this.userFactory.MapToUserDto(addedUser);
    }

    public async ValueTask<UserDto> RetrieveUserByIdAsync(Guid id)
    {

        var storageUser = await this.userRepository
            .SelectByIdAsync(id);

        var userValidator = new UserValidator().Validate(storageUser);

        if (!userValidator.IsValid)
        {
            string message = "";
            userValidator.Errors
                .ForEach(validation => { message += "\n" + validation.ErrorMessage; });
            throw new Exception(message);
        }

        return this.userFactory.MapToUserDto(storageUser);
    }

    public  IQueryable<UserDto> RetrieveUsers()
    {
        var storageUsers =  this.userRepository
            .SelectAll();

        return storageUsers.Select(storageUser => this.userFactory.MapToUserDto(storageUser));
    }

    public async ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto)
    {
        var validatorModify = new UserModifictionValidator().Validate(userForModificationDto);
        if (validatorModify.IsValid)
        {
            string message = "";
            validatorModify.Errors
                .ForEach(validation => { message += "\n" + validation.ErrorMessage; });
            throw new Exception(message);
        }

        var storageUser = await this.userRepository
            .SelectByIdAsync(userForModificationDto.id);

        if(storageUser is null)
        {
            string message = "Bunday foydalanuvchi yoq";
            throw new Exception(message);
        }

        this.userFactory.MapToUser(storageUser, userForModificationDto);

        var modifiedUser = await this.userRepository
            .UpdateAsync(storageUser);

        return this.userFactory.MapToUserDto(modifiedUser);
    }

    public async ValueTask<UserDto> RemoveUserAsync(Guid id)
    {
        

        var storageUser = await this.userRepository
            .SelectByIdAsync(id);

        var userValidator = new UserValidator().Validate(storageUser);

        if (!userValidator.IsValid)
        {
            string message = "";
            userValidator.Errors
                .ForEach(validation => { message += "\n" + validation.ErrorMessage; });
            throw new Exception(message);
        }

        var removedUser = await this.userRepository
            .DeleteAsync(storageUser);

        return this.userFactory.MapToUserDto(removedUser);
    }

}
