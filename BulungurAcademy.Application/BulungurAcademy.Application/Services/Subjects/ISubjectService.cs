using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Application.Services;
public interface ISubjectService
{
    ValueTask<Subject> CreateSubjectAsync(Subject subjectForCreation);
    IQueryable<Subject> RetrieveSubjects();
    ValueTask<Subject> RetrieveSubjectByIdAsync(Guid subjectId);
    ValueTask<Subject> ModifySubjectAsync(Subject subjectForModification);
    ValueTask<Subject> RemoveSubjectAsync(Guid subjectId);
}
