using BulungurAcademy.Application.DataTranferObjects;
using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Application.Services.Subjects;

public interface ISubjectFactory
{
    Subject MapToSubject(SubjectForCreationDto subjectDto);
}
