using BulungurAcademy.Application.DataTranferObjects;
using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Application.Services;
public interface ISubjectService
{
    ValueTask<Subject> CreateSubjectAsync(SubjectForCreationDto subjectForCreation);
    IQueryable<Subject> RetrieveSubjects();
    ValueTask<Subject> RetrieveSubjectByIdAsync(Guid subjectId);
    ValueTask<Subject> ModifySubjectAsync(Subject subjectForModification);
    ValueTask<Subject> RemoveSubjectAsync(Guid subjectId);
}
