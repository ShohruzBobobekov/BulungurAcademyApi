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
            SecondSubjectId = examApplicantDto.SecondSubjectId
        };
    }

    public ExamApplicantDto MapToExamApplicantDto(ExamApplicant examApplican)
    {
        return new ExamApplicantDto(
            examApplican.UserId,
            examApplican.ExamId,
            examApplican.FirstSubjectId,
            examApplican.SecondSubjectId
            );
    }
}
