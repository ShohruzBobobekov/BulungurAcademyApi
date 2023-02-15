using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BulungurAcademy.Application.DataTranferObjects.Users;

public record UserDto(
    Guid id,
    string firstName,
    string? lastName,
    string phoneNumber,
    UserRole role,
    IEnumerable<ExamApplicantDto>? examApplicants
    );
