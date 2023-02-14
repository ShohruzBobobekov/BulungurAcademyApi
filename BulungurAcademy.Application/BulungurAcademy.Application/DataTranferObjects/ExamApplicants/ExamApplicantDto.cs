using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Application.DataTranferObjects.Users;
using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Application.DataTranferObjects.ExamApplicants;

public record ExamApplicantDto(
     Guid UserId,
     Guid ExamId,
     Guid? FirstSubjectId,
     Guid? SecondSubjectId,
     UserDto UserDto,
     ExamDto ExamDto,
     Subject FirstSubject,
     Subject SecondSubject
);