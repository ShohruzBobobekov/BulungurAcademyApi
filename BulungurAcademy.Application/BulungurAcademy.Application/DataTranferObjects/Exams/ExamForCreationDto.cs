namespace BulungurAcademy.Application.DataTranferObjects.Exams;

public record ExamForCreationDto(
    string name,
    DateTime examDate,
    DateTime CreatedAt);
