using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Application.Services.ExamApplicants;
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
            userForCreationDto.telegramId,
            Domain.Enum.UserRole.User)
        {
            CreatedAt = DateTime.Now
        };
    }

    public void MapToUser(User storageUser, UserForModificationDto userForModificationDto)
    {
        storageUser.FirstName = userForModificationDto.firstName ?? storageUser.FirstName;
        storageUser.LastName = userForModificationDto.lastName ?? storageUser.LastName;
        storageUser.Phone = userForModificationDto.phoneNumber ?? storageUser.Phone;
        storageUser.Status = userForModificationDto.status ?? storageUser.Status;
        storageUser.UpdatedAt = DateTime.Now;
    }

}
