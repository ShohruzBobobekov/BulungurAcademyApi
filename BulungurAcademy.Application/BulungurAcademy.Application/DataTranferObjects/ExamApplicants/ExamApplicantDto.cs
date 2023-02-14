using BulungurAcademy.Application.DataTranferObjects.Users;

namespace BulungurAcademy.Application.DataTranferObjects.ExamApplicants;

public record ExamApplicantDto(
     Guid UserId,
     Guid ExamId,
     Guid? FirstSubjectId,
     Guid? SecondSubjectId,
     UserDto UserDto
     //SubjectDto FirstSubject,
     //SubjectDto SecondSubject
);