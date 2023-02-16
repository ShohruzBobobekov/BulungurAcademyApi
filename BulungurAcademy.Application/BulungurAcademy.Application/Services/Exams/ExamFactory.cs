using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public class ExamFactory : IExamFactory
{
    public Exam MapToExam(ExamForCreationDto creationDto)
    {
        return new Exam(
            examName: creationDto.name,
            examDate: creationDto.examDate);
    }

    /// <summary>
    /// Hozircha hech qayerga ishlatilmagan
    /// </summary>
    /// <param name="modificationDto"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Exam MapToExam(ExamForModificationDto modificationDto)
    {
        throw new NotImplementedException();
    }

    public ExamDto MapToExamDto(Exam exam)
    {
        return new ExamDto(
            id: exam.Id, 
            ExamName: exam.ExamName, exam.ExamDate);
    }
}
