using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public interface IExamService
{
    ValueTask<Exam> CreateExamAsync(ExamForCreationDto exam);
    ValueTask<Exam> CreateExamSubject(Guid examId, Guid subjectId);
    IQueryable<Exam> RetrieveExams();
    ValueTask<Exam> RetrieveExamByIdAsync(Guid id);
    ValueTask<Exam> RetrieveExamWithDetailsAsync(Guid id);
    ValueTask<Exam> ModifyExamAsync(ExamForModificationDto exam);
    ValueTask<Exam> RemoveExamAsync(Guid id);
}
