using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Domain.Entities.ExamSubjects;

public class ExamSubject
{
    public Guid ExamId { get; set; }
    public Guid SubjectId { get; set; }
    public Exam Exam { get; set; }
    public Subject Subject { get; set; }
}
