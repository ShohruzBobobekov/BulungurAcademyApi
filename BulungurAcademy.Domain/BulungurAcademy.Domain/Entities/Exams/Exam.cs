using BulungurAcademy.Domain.Entities.Common;

namespace BulungurAcademy.Domain.Entities.Exams;

public class Exam : Auditable
{
    public string? ExamName { get; set; }
    public DateTime ExamDate { get; set; }

    public ICollection<ExamApplicant>? ExamApplicants { get; set; }
}
