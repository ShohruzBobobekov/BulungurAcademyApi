using BulungurAcademy.Application.DataTranferObjects;
using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Application.Services.Subjects;

public class SubjectFactory : ISubjectFactory
{
    public Subject MapToSubject(SubjectForCreationDto subjectDto)
    {
        var subject = new Subject();
        subject.Name = subjectDto.name.ToUpper();
        subject.CreatedAt = DateTime.Now;
        return subject;
    }
}
