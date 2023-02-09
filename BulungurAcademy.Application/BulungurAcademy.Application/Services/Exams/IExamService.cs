using BulungurAcademy.Domain.Entities.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public interface IExamService
{
    IQueryable<Exam> RetrieveExams();
    ValueTask<Exam> RetrieveExamByIdAsync(Guid id);
    ValueTask<Exam> RetrieveExamWithDetailsAsync(Guid id);
    ValueTask<Exam> CreateExamAsync(Exam exam);
    ValueTask<Exam> ModifyExamAsync(Exam exam);
    ValueTask<Exam> RemoveExamAsync(Guid id);
}
