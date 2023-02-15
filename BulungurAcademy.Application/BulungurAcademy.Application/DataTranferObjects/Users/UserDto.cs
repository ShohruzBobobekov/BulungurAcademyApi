using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Domain.Enum;

namespace BulungurAcademy.Application.DataTranferObjects.Users;

public record UserDto(
    Guid id,
    string firstName,
    string? lastName,
    string phoneNumber,
    UserRole role,
    IEnumerable<ExamApplicant> examApplicants
    );
