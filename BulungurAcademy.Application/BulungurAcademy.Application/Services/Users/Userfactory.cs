using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Domain.Entities.Users;

namespace BulungurAcademy.Application.Services.Users;

public class Userfactory : IUserFactory
{
    public User MapToUser(UserForCreaterDto userForCreationDto)
    {
        return new User(
            userForCreationDto.firstName,
            userForCreationDto.lastName,
            userForCreationDto.phoneNumber,
            Domain.Enum.UserRole.User);
    }

    public void MapToUser(User storageUser, UserForModificationDto userForCreationDto)
    {
        storageUser.FirstName = userForCreationDto.firstName;
        storageUser.LastName = userForCreationDto.lastName;
        storageUser.Phone = userForCreationDto.phoneNumber;
    }

    public UserDto MapToUserDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Phone,
            user.UserRole);
    }
}
