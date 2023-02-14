namespace BulungurAcademy.Application.DataTranferObjects.Exams;

public record ExamForModificationDto(
    Guid Id,
    string? name,
    DateTime? examDate
    );
