using BulungurAcademy.Application.DataTranferObjects.ExamApplicants;
using BulungurAcademy.Application.Services.ExamApplicants;
using BulungurAcademy.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BulungurAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamApplicantsController : ControllerBase
    {
        private readonly IExamApplicantService service;

        public ExamApplicantsController(IExamApplicantService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ExamApplicant>> Post(
            ExamApplicantDto examApplicant)
        {
            var posted = await service.CreateExamApplicant(examApplicant);

            return Ok(posted);
        }

        [HttpGet]
        public IActionResult GetAllExamApplicants()
        {
            return Ok(service.RetriveAllExamApplicants());
        }

        [HttpGet("{examId:guid}")]
        public IActionResult GetExamApplicantsByExamId(Guid examId)
        {
            return Ok(service.RetriveExamApplicantsByExamId(examId));
        }
        [HttpGet("{SubjectId:guid}")]
         public IActionResult GetExamApplicantsBySubjectId(Guid subjectId)
        {
            return Ok(service.RetriveExamApplicantsBySubjectId(subjectId));
        }

        [HttpGet("{firstSubjectId:guid}")]
        public IActionResult GetExamApplicantsByFirstSubject(Guid firstSubjectId)
        {
            return Ok(service.RetriveExamApplicantByFirstSubjectId(firstSubjectId));
        }

        [HttpGet("{secontSubject:guid}")]
        public IActionResult GetExamApplicantsBySecondSubject(Guid secondSubjectId) 
        {
            return Ok(service.RetriveExamApplicantBySecondSubjectId(secondSubjectId));
        }

        [HttpPut]
        public IActionResult PutExamApplicant(ExamApplicantDto examApplicantDto)
        {
            return Ok(service.ModifyExamApplicant(examApplicantDto));
        }

        [HttpDelete]
        public IActionResult DeleteExamApplicant(ExamApplicantDto examApplicantDto)
        {
            return Ok(service.RemoveExamApplicant(examApplicantDto));
        }
    }
}
