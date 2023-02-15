using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Domain.Entities.Users;

namespace BulungurAcademy.Application.Services.Users;

public interface IUserService
{
    ValueTask<User> CreateUserAsync(UserForCreaterDto userForCreaterDto);
    ValueTask<User> RetrieveUserByIdAsync(Guid id);
    IQueryable<UserDto> RetrieveUsers();
    ValueTask<User> ModifyUserAsync(UserForModificationDto userForModificationDto);
    ValueTask<User> RemoveUserAsync(Guid id);
}
