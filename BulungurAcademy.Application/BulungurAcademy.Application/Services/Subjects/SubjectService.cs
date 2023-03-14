using BulungurAcademy.Application.DataTranferObjects;
using BulungurAcademy.Application.Services.Subjects;
using BulungurAcademy.Domain.Entities.Subjects;
using BulungurAcademy.Infrastructure.Repositories.Subjects;

namespace BulungurAcademy.Application.Services;
public partial class SubjectService : ISubjectService
{
    private readonly ISubjectRepository subjectRepository;
    private readonly ISubjectFactory factory;
    public SubjectService(ISubjectRepository subjectRepository, ISubjectFactory factory)
    {
        this.subjectRepository = subjectRepository;
        this.factory = factory;
    }

    public async ValueTask<Subject> CreateSubjectAsync(SubjectForCreationDto subjectForCreationDto)
    {
        // ValidateForCreation(subjectForCreation);

        //subjectForCreationDto.name = subjectForCreationDto.name.ToUpper();
        var subject = factory.MapToSubject(subjectForCreationDto);
        var storageSubject = await this.subjectRepository
            .InsertAsync(subject);

        ValidateStorageSubject(
            storageSubject: storageSubject,
            subjectId: subject.Id);

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

        return removeSubject;
    }
}
