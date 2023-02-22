using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Domain.Exceptions;

namespace BulungurAcademy.Application.Services.Exams;
public partial class ExamService
{
    public void ValidationExam(Guid examId)
    {
        if (examId == default)
        {
            throw new ValidationException($"The given subjectId: {examId} is invalid.");
        }
    }
    public void ValidationStorageExam(Exam storageExam, Guid examId)
    {
        if(storageExam == null)
        {
            throw new NotFoundException($"Couldn't find subject with given id: {examId}.");
        }
    }
    public void ValidationForCreation(ExamForCreationDto exam)
    {
        if (exam == null)
        {
            throw new ValidationException($"The given {exam} is invalid.");
        }
    }
    public void ValidationForModify(ExamForModificationDto exam)
    {
        if (exam == null)
        {
            throw new ValidationException($"The given {exam} is invalid.");
        }
    }
}
