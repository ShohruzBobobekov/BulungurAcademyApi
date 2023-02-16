using BulungurAcademy.Domain.Entities.Common;
using BulungurAcademy.Domain.Entities.ExamSubjects;

namespace BulungurAcademy.Domain.Entities.Exams;

public class Exam : Auditable
{
    public string? ExamName { get; set; }
    public DateTime ExamDate { get; set; }
    public Exam() { }
    public Exam(string? examName, DateTime examDate = default)
    {
        ExamName = examName;
        ExamDate = examDate;
    }

    public ICollection<ExamApplicant>? ExamApplicants { get; set; }
    public ICollection<ExamSubject>? ExamSubjects { get; set; }
}
