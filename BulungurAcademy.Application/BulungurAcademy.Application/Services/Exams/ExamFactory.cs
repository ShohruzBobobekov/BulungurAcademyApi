using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public class ExamFactory : IExamFactory
{
    public Exam MapToExam(ExamForCreationDto creationDto)
    {
        throw new NotImplementedException();
    }

    public Exam MapToExam(ExamForModificationDto modificationDto)
    {
        throw new NotImplementedException();
    }

    public ExamDto MapToExamDto(Exam exam)
    {
        throw new NotImplementedException();
    }
}
