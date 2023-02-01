using BulungurAcademy.Application.DataTranferObjects;

namespace BulungurAcademy.Application.Services;
public interface ISubjectService
{
    ValueTask<SubjectDto> CreateUserAsync(SubjectForCreationDto subjectForCreationDto);
    IQueryable<SubjectDto> RetrieveUsers(/*QueryParameter queryParameter*/);
    ValueTask<SubjectDto> RetrieveUserByIdAsync(Guid subjectId);
    ValueTask<SubjectDto> ModifyUserAsync(SubjectForModificationDto subjectForModificationDto);
    ValueTask<SubjectDto> RemoveUserAsync(Guid subrectId);
}
