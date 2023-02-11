using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Domain.Entities;

namespace BulungurAcademy.Application.Services.ExamApplicants;

public interface IExamApplicantFatory
{
    ExamApplicant MapToExamApplicant(ExamApplicantDto examApplicantDto);
    ExamApplicantDto MapToExamApplicantDto(ExamApplicant examApplican);
}
