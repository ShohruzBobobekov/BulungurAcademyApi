namespace BulungurAcademy.Application.DataTranferObjects.Exams;

public record ExamForModificationDto(
    string? name,
    DateTime? examDate,
    IList<SubjectForCreationDto>? examSubjects,
    DateTime updateAt);
