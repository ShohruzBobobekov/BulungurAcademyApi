using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Infrastructure.Repositories.Exams;

namespace BulungurAcademy.Application.Services.Exams;

public partial class ExamService : IExamService
{
    private readonly IExamRepository examRepository;
    private readonly IExamFactory factory;
    public ExamService(IExamRepository examRepository, IExamFactory factory)
    {
        this.examRepository = examRepository;
        this.factory = factory;
    }

    public async ValueTask<Exam> CreateExamAsync(ExamForCreationDto exam)
    {
        ValidationForCreation(exam: exam);

        var  inserted= await examRepository.InsertAsync(factory.MapToExam(exam));

        return inserted;
    }

    public IQueryable<Exam> RetrieveExams()
        => this.examRepository.SelectAll();

    public async ValueTask<Exam> RetrieveExamByIdAsync(Guid id)
    {
        ValidationExam(examId: id);

        var storageExam = await examRepository.SelectByIdAsync(id);

        ValidationStorageExam(storageExam: storageExam, examId: id);

        return storageExam; 
    }

    public async ValueTask<Exam> RetrieveExamWithDetailsAsync(Guid id)
    {
        ValidationExam(examId: id);

        var storageExam = await examRepository
            .SelectByIdWithDetailsAsync(exam => exam.Id == id,
            new string[] { "Subjects", "ExamApplicants" });

        ValidationStorageExam(storageExam: storageExam, examId: id);
        
        return storageExam;
    }

    public async ValueTask<Exam> ModifyExamAsync(ExamForModificationDto exam)
    {
        ValidationForModify(exam: exam);

        var storageExam = await examRepository.SelectByIdAsync(exam.Id);

        ValidationStorageExam(storageExam: storageExam, examId: exam.Id);

        storageExam.UpdatedAt = DateTime.Now;
        storageExam.ExamDate = (DateTime)(exam.examDate == null ? storageExam.ExamDate : exam.examDate);
        storageExam.ExamName = exam.name == null ? storageExam.ExamName : exam.name;
        
        var updated= await examRepository.UpdateAsync(storageExam);

        return updated;
    }

    public async ValueTask<Exam> RemoveExamAsync(Guid id)
    {
        ValidationExam(examId: id);

        var storageExam = await examRepository.SelectByIdAsync(id);

        ValidationStorageExam(storageExam: storageExam, examId: id);

        var deleted= await examRepository.DeleteAsync(storageExam);

        return deleted;
    }

}
