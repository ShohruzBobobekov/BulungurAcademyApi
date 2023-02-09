using BulungurAcademy.Domain.Entities.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public interface IExamService
{
    ValueTask<Exam> CreateExamAsync(Exam exam);
    IQueryable<Exam> RetrieveExams();
    ValueTask<Exam> RetrieveExamByIdAsync(Guid id);
    ValueTask<Exam> RetrieveExamWithDetailsAsync(Guid id);
    ValueTask<Exam> ModifyExamAsync(Exam exam);
    ValueTask<Exam> RemoveExamAsync(Guid id);
}
