namespace BulungurAcademy.Application.DataTranferObjects.Users;

public record UserForCreaterDto(
    string firstName,
    string? lastName,
    string phoneNumber,
    long? telegramId
    );

