using BulungurAcademy.Application.DataTranferObjects.Users;
namespace BulungurAcademy.Application.Services.Users;

public interface IUserService
{
    ValueTask<UserDto> CreateUserAsync(UserForCreaterDto userForCreaterDto);
    ValueTask<UserDto> RetrieveUserByIdAsync(Guid id);
    IQueryable<UserDto> RetrieveUsers();
    ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
    ValueTask<UserDto> RemoveUserAsync(Guid id);
}
