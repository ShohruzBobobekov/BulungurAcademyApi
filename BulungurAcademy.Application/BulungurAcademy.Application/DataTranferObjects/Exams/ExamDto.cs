namespace BulungurAcademy.Application.DataTranferObjects.Exams;

public record ExamDto(
    Guid id,
    string? ExamName,
    DateTime ExamDate
    );
