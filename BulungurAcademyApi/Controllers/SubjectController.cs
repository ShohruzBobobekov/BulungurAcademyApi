using BulungurAcademy.Application.Services;
using BulungurAcademy.Domain.Entities.Subjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulungurAcademy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService subjectService;
    public SubjectController(ISubjectService subjectService)
        => this.subjectService = subjectService;

    [HttpPost]
    public async ValueTask<ActionResult<Subject>> PostSubjectAsync(Subject subject)
    {
        var createSubject = await this.subjectService
            .CreateSubjectAsync(subjectForCreation: subject);

        return Created("", createSubject);
    }
    [HttpGet]
    public IActionResult GetSubjects()
    {
        var subjects = this.subjectService
            .RetrieveSubjects();

        return Ok(subjects);
    }
    [HttpGet("{subjectId:guid}")]
    public async ValueTask<ActionResult<Subject>> GetSubjectById(Guid subjectId)
    {
        var subject = await this.subjectService
            .RetrieveSubjectByIdAsync(subjectId: subjectId);

        return Ok(subject);
    }
    [HttpPut]
    public async ValueTask<ActionResult<Subject>> PutSubjectAsync(Subject subject)
    {
        var modifySubject = await this.subjectService
            .ModifySubjectAsync(subjectForModification: subject);

        return Ok(modifySubject);
    }
    [HttpDelete("{subjectId:guid}")]
    public async ValueTask<ActionResult<Subject>> DeleteSubjectAsync(Guid subjectId)
    {
        var removedSubject = await this.subjectService
            .RemoveSubjectAsync(subjectId: subjectId);

        return Ok(removedSubject);
    }
}
