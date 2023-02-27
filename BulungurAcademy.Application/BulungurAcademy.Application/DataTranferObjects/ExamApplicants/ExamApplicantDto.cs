namespace BulungurAcademy.Application.DataTranferObjects.ExamApplicants;

public record ExamApplicantDto(
     Guid UserId,
     Guid ExamId,
     Guid? FirstSubjectId,
     Guid? SecondSubjectId
);