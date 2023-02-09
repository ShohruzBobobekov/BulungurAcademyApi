using BulungurAcademy.Domain.Entities;
using FluentValidation;

namespace BulungurAcademy.Application.Validation.ExamApplicants;

public class ExamApplicantValidator : AbstractValidator<ExamApplicant>
{
    public ExamApplicantValidator()
    {
        RuleFor(examApplicant => examApplicant)
            .NotNull();

        RuleFor(examApplicant => examApplicant.ExamId)
            .NotNull()
            .NotEmpty();

        RuleFor(examApplicant => examApplicant.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(examApplicant => examApplicant.FirstSubjectId)
            .NotNull()
            .NotEmpty();

        RuleFor(examApplicant => examApplicant.SecondSubjectId)
            .NotNull()
            .NotEmpty();
    }
}
