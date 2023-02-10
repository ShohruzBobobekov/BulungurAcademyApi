using BulungurAcademy.Application.Validation.ExamApplicants;
using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Infrastructure.Repositories.ExamApplicants;

namespace BulungurAcademy.Application.Services.ExamApplicants;

public class ExamApplicantService : IExamApplicantService
{
    private readonly IExamApplicantRepository repository;

    public ExamApplicantService(IExamApplicantRepository repository)
    {
        this.repository = repository;
    }

    public async ValueTask<ExamApplicant> CreateExamApplicant(ExamApplicant examApplicant)
    {
        var validationResult = new ExamApplicantValidator().Validate(examApplicant);
        if (!validationResult.IsValid)
        {
            string message = "";
            validationResult.Errors
                .ForEach(validation =>
                {
                    message += "\n" + validation.ErrorMessage;
                });
            throw new Exception(message);
        }

        var inserted = await repository.InsertAsync(examApplicant);

        return await repository.SelectByIdWithDetailsAsync(inserted.ExamId, inserted.UserId);
    }

    public IQueryable<ExamApplicant> RetriveAllExamApplicants()
    {
        return repository.SelectAll();
    }

    public IQueryable<ExamApplicant> RetriveExamApplicantByFirstSubjectId(Guid subjectId)
    {
        return repository.SelectAllWithDetailsAsync(examApplicant =>
        examApplicant.FirstSubjectId == subjectId,
        new string[] { "User", "Exam", "FirstSubject", "SecondSubject" });
    }

    public IQueryable<ExamApplicant> RetriveExamApplicantBySecondSubjectId(Guid subjectId)
    {
        return repository.SelectAllWithDetailsAsync(examApplicant =>
        examApplicant.SecondSubjectId == subjectId,
        new string[] { "User", "Exam", "FirstSubject", "SecondSubject" });
    }

    public IQueryable<ExamApplicant> RetriveExamApplicantBySubjectId(Guid subjectId)
    {
        return repository.SelectAllWithDetailsAsync(examApplicant =>
        examApplicant.FirstSubjectId == subjectId ||
        examApplicant.SecondSubjectId == subjectId,
        new string[] { "User", "Exam", "FirstSubject", "SecondSubject" });
    }

    public IQueryable<ExamApplicant> RetriveExamApplicantsByExamId(Guid examId)
    {
        return repository.SelectAllWithDetailsAsync(examApplicant => true,
            new string[] { "User", "Exam", "FirstSubject", "SecondSubject" });
    }

    public async ValueTask<ExamApplicant> ModifyExamApplicant(ExamApplicant examApplicant)
    {
        return await repository.UpdateAsync(examApplicant);
    }

    public async ValueTask<ExamApplicant> RemoveExamApplicant(ExamApplicant examApplicant)
    {
        return await repository.DeleteAsync(examApplicant);
    }
}
