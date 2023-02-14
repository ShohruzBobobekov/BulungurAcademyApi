using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public interface IExamFactory
{
    Exam MapToExam(ExamForCreationDto creationDto);
    Exam MapToExam(ExamForModificationDto modificationDto);
    ExamDto MapToExamDto(Exam exam);
}
