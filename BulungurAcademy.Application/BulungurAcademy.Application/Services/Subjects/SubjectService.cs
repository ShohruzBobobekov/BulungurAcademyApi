using BulungurAcademy.Application.DataTranferObjects;
using BulungurAcademy.Infrastructure.Repositories.Subjects;

namespace BulungurAcademy.Application.Services;
public partial class SubjectService : ISubjectService
{
    private readonly ISubjectRepository subjectRepository;
    public SubjectService(ISubjectRepository subjectRepository)
    {
        this.subjectRepository = subjectRepository;
    }

    /// <summary>
    /// C R E A T E 
    /// </summary>
    public async ValueTask<SubjectDto> CreateUserAsync(SubjectForCreationDto subjectForCreationDto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///  G E T all
    /// </summary>
    public IQueryable<SubjectDto> RetrieveUsers(/*QueryParameter queryParameter*/)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///  G E T byId
    /// </summary>
    public async ValueTask<SubjectDto> RetrieveUserByIdAsync(Guid subjectId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// U P D A T E
    /// </summary>
    public async ValueTask<SubjectDto> ModifyUserAsync(SubjectForModificationDto subjectForModificationDto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// R E M O V E 
    /// </summary>
    public async ValueTask<SubjectDto> RemoveUserAsync(Guid subrectId)
    {
        throw new NotImplementedException();
    }
}
