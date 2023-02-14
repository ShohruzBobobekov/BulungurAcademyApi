using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Application.Services.Exams;
using BulungurAcademy.Application.Services.Users;
using BulungurAcademy.Domain.Entities;

namespace BulungurAcademy.Application.Services.ExamApplicants;
public class ExamApplicantFatory : IExamApplicantFatory
{
    private readonly IUserFactory userFactory;
    private readonly IExamFactory examFactory;
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

    public ExamApplicantDto MapToExamApplicantDto(ExamApplicant examApplicant)
    {
        return new ExamApplicantDto(
            examApplicant.UserId,
            examApplicant.ExamId,
            examApplicant.FirstSubjectId,
            examApplicant.SecondSubjectId,
            userFactory.MapToUserDto(examApplicant.User),
            examFactory.MapToExamDto(examApplicant.Exam),
            examApplicant.FirstSubject,
            examApplicant.SecondSubject
            );
    }
}
