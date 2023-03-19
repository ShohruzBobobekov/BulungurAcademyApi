using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Domain.Entities;

namespace BulungurAcademy.Application.Services.ExamApplicants;
public class ExamApplicantFatory : IExamApplicantFatory
{
    public ExamApplicant MapToExamApplicant(ExamApplicantDto examApplicantDto)
    {
        return new ExamApplicant()
        {
            UserId = examApplicantDto.UserId,
            ExamId = examApplicantDto.ExamId,
            FirstSubjectId = examApplicantDto.FirstSubjectId,
            SecondSubjectId = examApplicantDto.SecondSubjectId,
            PaymentStatus = examApplicantDto.PaymentStatus,
            AttendanceStatus = examApplicantDto.AttendanceStatus
        };
    }

    public ExamApplicantDto MapToExamApplicantDto(ExamApplicant examApplicant)
    {
        return new ExamApplicantDto(
            examApplicant.UserId,
            examApplicant.ExamId,
            examApplicant.FirstSubjectId,
            examApplicant.SecondSubjectId,
            examApplicant.PaymentStatus,
            examApplicant.AttendanceStatus
            );
    }
}
