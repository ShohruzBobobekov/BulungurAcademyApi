using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Domain.Entities.Users;

namespace BulungurAcademy.Application.Services.Users;

public interface IUserFactory
{
    User MapToUser(UserForCreaterDto userForCreationDto);
    void MapToUser(User storageUser, UserForModificationDto userForCreationDto);
}
