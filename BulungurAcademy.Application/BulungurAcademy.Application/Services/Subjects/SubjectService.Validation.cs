using BulungurAcademy.Domain.Entities.Subjects;

namespace BulungurAcademy.Application.Services;
public partial class SubjectService
{
    public void ValidateSubject(Guid subjectId)
    {
        if (subjectId == default)
        {
            throw new ArgumentNullException($"The given subjectId: {subjectId} is invalid.");
        }
    }
    public void ValidateStorageSubject(Subject storageSubject, Guid subjectId)
    {
        if(storageSubject == null)
        {
            throw new ArgumentNullException($"Couldn't find subject with given id: {subjectId}.");
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
                throw new Exception($"This subject which {subject.Name} already exists in Database.");
            }
        }
    }
}
