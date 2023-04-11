using BulungurAcademy.Domain.Entities.Common;
using BulungurAcademy.Domain.Entities.Subjects;

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
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public ICollection<ExamApplicant>? ExamApplicants { get; set; }
    public ICollection<Subject>? Subjects { get; set; }
    public string GetExamDateToString()
    {
        return $"Imtihon kuni: {ExamDate.Year}-yil, " +
            $"{ExamDate.ToString("MMMM")} " +
            $"{ExamDate.Day},\n" +
            $"Imtihon vaqti:  {ExamDate.ToString("HH:MM")}\n\n";
    }
}
