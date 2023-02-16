using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Domain.Entities.Subjects;
using Telegram.Bot.Types.InlineQueryResults;

namespace BulungurAcademy.Application.Services.Exams;
public partial class ExamService
{
    public void ValidationExam(Guid examId)
    {
        if (examId == default)
        {
            throw new ArgumentNullException($"The given subjectId: {examId} is invalid.");
        }
    }
    public void ValidationStrageExam(Exam storageExam, Guid examId)
    {
        if(storageExam == null)
        {
            throw new ArgumentNullException($"Couldn't find subject with given id: {examId}.");
        }
    }
    public void ValidationForCreation(ExamForCreationDto exam)
    {
        if (exam == null)
        {
            throw new ArgumentNullException($"The given {exam} is invalid.");
        }
    }
    public void ValidationForModify(ExamForModificationDto exam)
    {
        if (exam == null)
        {
            throw new ArgumentNullException($"The given {exam} is invalid.");
        }
    }
}
