using BulungurAcademy.Domain.Entities.Subjects;
using BulungurAcademy.Domain.Exceptions;

namespace BulungurAcademy.Application.Services;
public partial class SubjectService
{
    public void ValidateSubject(Guid subjectId)
    {
        if (subjectId == default)
        {
            throw new ValidationException($"The given subjectId: {subjectId} is invalid.");
        }
    }
    public void ValidateStorageSubject(Subject storageSubject, Guid subjectId)
    {
        if(storageSubject == null)
        {
            throw new NotFoundException($"Couldn't find subject with given id: {subjectId}.");
        }
    }
    public void ValidateForCreation(Subject forCreationSubject)
    {
        var subjects = RetrieveSubjects();
        var subjectName = forCreationSubject.Name.ToUpper();

        foreach (var subject in subjects) 
        {
            if(subjectName == subject.Name)
            {
                throw new ValidationException($"This subject which {subject.Name} already exists in Database.");
            }
        }
    }
}
