using BulungurAcademy.Domain.Entities;

namespace BulungurAcademy.Infrastructure.Repositories.ExamApplicants;

public interface IExamApplicantRepository : IRepository<ExamApplicant>
{
    /// <summary>
    /// examId va userId bo'yicha ExamApplicant ro'yhatini yuklab oladi.
    /// examId va userId Compozit key.
    /// </summary>
    /// <param name="examId"></param>
    /// <param name="userId"></param>
    /// <returns name="ExamApplicant"></returns>
    ValueTask<ExamApplicant> SelectByIdWithDetailsAsync(Guid examId, Guid userId);
}
