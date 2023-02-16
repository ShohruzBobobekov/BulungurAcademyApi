using BulungurAcademy.Domain.Entities.Subjects;
using BulungurAcademy.Infrastructure.Repositories.Subjects;

namespace BulungurAcademy.Application.Services;
public partial class SubjectService : ISubjectService
{
    private readonly ISubjectRepository subjectRepository;
    public SubjectService(ISubjectRepository subjectRepository)
        => this.subjectRepository = subjectRepository;

    public async ValueTask<Subject> CreateSubjectAsync(Subject subjectForCreation)
    {
        ValidateForCreation(subjectForCreation);

        subjectForCreation.Name = subjectForCreation.Name.ToUpper();

        var storageSubject = await this.subjectRepository
            .InsertAsync(subjectForCreation);

        ValidateStorageSubject(
            storageSubject: storageSubject,
            subjectId: subjectForCreation.Id);

        await this.subjectRepository.SaveChangesAsync();

        return storageSubject;
    }

    public IQueryable<Subject> RetrieveSubjects()
        => this.subjectRepository.SelectAll();

    public async ValueTask<Subject> RetrieveSubjectByIdAsync(Guid subjectId)
    {
        ValidateSubject(subjectId);

        var storageSubject = await this.subjectRepository.SelectByIdAsync(subjectId);

        ValidateStorageSubject(
            storageSubject: storageSubject,
            subjectId: subjectId);

        return storageSubject;
    }

    public async ValueTask<Subject> ModifySubjectAsync(Subject subjectForModification)
    {
        ValidateStorageSubject(
            storageSubject: subjectForModification, 
            subjectId: subjectForModification.Id);

        subjectForModification.Name = subjectForModification.Name.ToUpper();

        var storageSubject = await this.subjectRepository.UpdateAsync(subjectForModification);

        ValidateStorageSubject(
            storageSubject: storageSubject,
            subjectId: subjectForModification.Id);

        await this.subjectRepository.SaveChangesAsync();

        return storageSubject;
    }

    public async ValueTask<Subject> RemoveSubjectAsync(Guid subjectId)
    {
        ValidateSubject(subjectId: subjectId);

        var storageSubject = await this.RetrieveSubjectByIdAsync(subjectId);

        ValidateStorageSubject(
            storageSubject: storageSubject,
            subjectId: subjectId);

        var removeSubject = await this.subjectRepository.DeleteAsync(storageSubject);
        
        await this.subjectRepository.SaveChangesAsync();

        return removeSubject;
    }
}
