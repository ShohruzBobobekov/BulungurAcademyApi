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

        var inserted = await repository.InsertAsync(examApplicant);
        await repository.SaveChangesAsync();
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

    public async ValueTask<ExamApplicant> ModifyExamApplicant(ExamApplicantDto examApplicantDto)
    {
        var updated= await repository.UpdateAsync(factory.MapToExamApplicant(examApplicantDto));
        await repository.SaveChangesAsync();
        return updated;
    }

    public async ValueTask<ExamApplicant> RemoveExamApplicant(ExamApplicant examApplicant)
    {
        var removed= await repository.DeleteAsync(examApplicant);
        await repository.SaveChangesAsync();
        return removed;
    }
}
