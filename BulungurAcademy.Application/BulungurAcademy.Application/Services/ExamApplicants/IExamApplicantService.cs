using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Domain.Entities;

namespace BulungurAcademy.Application.Services.ExamApplicants;

public interface IExamApplicantService
{
    ValueTask<ExamApplicant> CreateExamApplicant(ExamApplicantDto examApplicantDto);
    IQueryable<ExamApplicant> RetriveAllExamApplicants();
    IQueryable<ExamApplicant> RetriveExamApplicantsByExamId(Guid examId);
    IQueryable<ExamApplicant> RetriveExamApplicantsBySubjectId(Guid subjectId);  
    IQueryable<ExamApplicant> RetriveExamApplicantByFirstSubjectId(Guid subjectId);
    IQueryable<ExamApplicant> RetriveExamApplicantBySecondSubjectId(Guid subjectId);
    ValueTask<ExamApplicant> ModifyExamApplicant(ExamApplicantDto examApplicantDto);
    ValueTask<ExamApplicant> RemoveExamApplicant(ExamApplicantDto examApplicant);
}
