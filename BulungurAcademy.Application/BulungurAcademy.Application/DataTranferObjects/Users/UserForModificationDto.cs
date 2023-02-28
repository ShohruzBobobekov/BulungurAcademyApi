using BulungurAcademy.Domain.Enum;

namespace BulungurAcademy.Application.DataTranferObjects.Users;

public record UserForModificationDto(
    Guid id,
    string? firstName,
    string? lastName,
    string? phoneNumber,
    UserStatus? status
    );
