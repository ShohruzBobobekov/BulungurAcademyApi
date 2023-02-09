using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Infrastructure.Repositories.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public class ExamService : IExamService
{
    private readonly IExamRepository examRepository;

    public ExamService(IExamRepository examRepository)
    {
        this.examRepository = examRepository;
    }

    public async ValueTask<Exam> CreateExamAsync(Exam exam)
    {
        return await examRepository.InsertAsync(exam);
    }

    public async ValueTask<Exam> ModifyExamAsync(Exam exam)
    {
        var storageExam = await examRepository.SelectByIdAsync(exam.Id);

        if (storageExam == null)
        {
            throw new Exception("Exam not found");
        }

        storageExam.UpdatedAt = DateTime.Now;
        storageExam.ExamDate = exam.ExamDate == null ? storageExam.ExamDate : exam.ExamDate;
        storageExam.ExamName = exam.ExamName == null ? storageExam.ExamName : exam.ExamName;
        
        return await examRepository.UpdateAsync(storageExam);
    }

    public async ValueTask<Exam> RemoveExamAsync(Guid id)
    {
        var storageExam = await examRepository.SelectByIdAsync(id);

        if (storageExam is null)
        {
            throw new Exception("Exam not found");
        }

        return await examRepository.DeleteAsync(storageExam);
    }

    public async ValueTask<Exam> RetrieveExamByIdAsync(Guid id)
    {
        return await examRepository.SelectByIdAsync(id);
    }

    public IQueryable<Exam> RetrieveExams()
    {
        return examRepository.SelectAll();
    }

    public async ValueTask<Exam> RetrieveExamWithDetailsAsync(Guid id)
    {
        var storageExam = await examRepository
            .SelectByIdWithDetailsAsync(exam => exam.Id == id,
            new string[] { "ExamSubject" });

        if (storageExam is null)
        {
            throw new Exception("Exam not found");
        }

        return storageExam;
    }
}
