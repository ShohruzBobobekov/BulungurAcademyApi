using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Application.Validation.Users;
using BulungurAcademy.Domain.Entities.Users;
using BulungurAcademy.Infrastructure.Repositories.Users;

namespace BulungurAcademy.Application.Services.Users;

public partial class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;
    public UserService(IUserRepository userRepository, IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }

    public async ValueTask<User> CreateUserAsync(UserForCreaterDto userForCreaterDto)
    {
        ValidationUserForCreationDto(userForCreaterDto: userForCreaterDto);

        var newUser = this.userFactory
            .MapToUser(userForCreaterDto);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return addedUser;
    }

    public async ValueTask<User> RetrieveUserByIdAsync(Guid id)
    {
        ValidationUserId(userId: id);

        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(x => x.Id==id, new string[] { "ExamApplicants" });

        ValidationStorageUser(storageUser: storageUser, userId: id);

        return storageUser;
    }

    public async ValueTask<User> RetrieveUserByTelegramIdAsync(long telegramId)
    {
        ValidationTelegramId(telegramId: telegramId);

        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(x => x.TelegramId == telegramId, new string[] { "ExamApplicants" });

        ValidationStorageUserWithTelegramId(storageUser: storageUser, telegramId: telegramId);

        return storageUser;
    }

    public IQueryable<UserDto> RetrieveUsers()
    {
        var storageUsers = this.userRepository
            .SelectAllWithDetailsAsync(x => true, new string[] { "ExamApplicants" });

        return storageUsers.Select(storageUser => this.userFactory.MapToUserDto(storageUser));
    }

    public async ValueTask<User> ModifyUserAsync(UserForModificationDto userForModificationDto)
    {
        ValidationUserForModificationDto(userForModificationDto: userForModificationDto);

        var storageUser = await this.userRepository
            .SelectByIdAsync(userForModificationDto.id);

        ValidationStorageUser(storageUser: storageUser, userId: userForModificationDto.id);

        this.userFactory.MapToUser(storageUser, userForModificationDto);

        var modifiedUser = await this.userRepository
            .UpdateAsync(storageUser);


        return modifiedUser;
    }

    public async ValueTask<User> RemoveUserAsync(Guid id)
    {
        ValidationUserId(userId: id);

        var storageUser = await this.userRepository
            .SelectByIdAsync(id);

        ValidationStorageUser(storageUser: storageUser, userId: id);

        /*var userValidator = new UserValidator().Validate(storageUser);

        if (!userValidator.IsValid)
        {
            string message = "";
            userValidator.Errors
                .ForEach(validation => { message += "\n" + validation.ErrorMessage; });
            throw new Exception(message);
        }*/

        var removedUser = await this.userRepository
            .DeleteAsync(storageUser);

        return removedUser;
    }

}
