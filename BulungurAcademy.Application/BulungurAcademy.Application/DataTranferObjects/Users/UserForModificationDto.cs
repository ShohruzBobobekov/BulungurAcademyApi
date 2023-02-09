namespace BulungurAcademy.Application.DataTranferObjects.Users;

public record UserForModificationDto(
    string? firstName,
    string? lastName,
    string? phoneNumber
    );
