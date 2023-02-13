using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Application.Validation.Users;
using BulungurAcademy.Infrastructure.Repositories.Users;

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
        if (!validationResult.IsValid)
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

        await userRepository.SaveChangesAsync();

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
            .SelectAllWithDetailsAsync(x => true,new string[] { "ExamApplicants" });

        return storageUsers.Select(storageUser => this.userFactory.MapToUserDto(storageUser));
    }

    public async ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto)
    {
        var validatorModify = new UserModifictionValidator().Validate(userForModificationDto);
        if (!validatorModify.IsValid)
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

        await userRepository.SaveChangesAsync();

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

        await userRepository.SaveChangesAsync();

        return this.userFactory.MapToUserDto(removedUser);
    }

}
