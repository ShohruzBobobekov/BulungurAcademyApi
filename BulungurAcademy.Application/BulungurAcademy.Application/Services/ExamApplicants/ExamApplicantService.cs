using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Application.Validation.ExamApplicants;
using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Infrastructure.Repositories.ExamApplicants;

namespace BulungurAcademy.Application.Services.ExamApplicants;

public class ExamApplicantService : IExamApplicantService
{
    private readonly IExamApplicantRepository repository;
    private readonly IExamApplicantFatory factory;

    public ExamApplicantService(IExamApplicantRepository repository, IExamApplicantFatory factory)
    {
        this.repository = repository;
        this.factory = factory;
    }

    public async ValueTask<ExamApplicant> CreateExamApplicant(ExamApplicantDto examApplicantDto)
    {
        var validationResult = new ExamApplicantValidator().Validate(examApplicantDto);


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

        var examApplicant = factory.MapToExamApplicant(examApplicantDto);
        examApplicant.CreatedAt = DateTime.UtcNow.AddHours(5);
        var inserted = await repository.InsertAsync(examApplicant);
        return await repository.SelectByIdWithDetailsAsync(inserted.ExamId, inserted.UserId);
    }

    public IQueryable<ExamApplicant> RetriveAllExamApplicants()
    {
        return repository.SelectAllWithDetailsAsync(
            ea => true,
            new string[] { "User", "Exam", "FirstSubject", "SecondSubject" });
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

    public IQueryable<ExamApplicant> RetriveExamApplicantsBySubjectId(Guid subjectId)
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

    public async ValueTask<ExamApplicant> ModifyExamApplicant(ExamApplicantDto examApplicantDto)
    {
        var examApplicant = factory.MapToExamApplicant(examApplicantDto);
        examApplicant.UpdatedAt = DateTime.UtcNow.AddHours(5);
        var updated = await repository.UpdateAsync(examApplicant);
        return updated;
    }

    public async ValueTask<ExamApplicant> RemoveExamApplicant(ExamApplicantDto examApplicantDto)
    {
        var removed = await repository.DeleteAsync(factory.MapToExamApplicant(examApplicantDto));
        return removed;
    }
}
