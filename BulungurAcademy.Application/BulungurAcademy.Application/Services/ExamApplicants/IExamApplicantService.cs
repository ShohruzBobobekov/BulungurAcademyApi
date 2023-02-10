using BulungurAcademy.Domain.Entities;

namespace BulungurAcademy.Application.Services.ExamApplicants;

public interface IExamApplicantService
{
    ValueTask<ExamApplicant> CreateExamApplicant(ExamApplicant examApplicant);
    IQueryable<ExamApplicant> RetriveExamApplicantsByExamId(Guid examId);
    IQueryable<ExamApplicant> RetriveExamApplicantBySubjectId(Guid subjectId);
    IQueryable<ExamApplicant> RetriveExamApplicantByFirstSubjectId(Guid subjectId);
    IQueryable<ExamApplicant> RetriveExamApplicantBySecondSubjectId(Guid subjectId);
    ValueTask<ExamApplicant> ModifyExamApplicant(ExamApplicant examApplicant);
    ValueTask<ExamApplicant> RemoveExamApplicant(ExamApplicant examApplicant);
}
