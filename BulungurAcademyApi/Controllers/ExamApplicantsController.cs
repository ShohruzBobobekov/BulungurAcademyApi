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
            => this.service = service;

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

        [HttpGet("exam/{Id}:guid")]
        public IActionResult GetExamApplicantsByExamId(Guid Id)
        {
            return Ok(service.RetriveExamApplicantsByExamId(Id));
        }
        [HttpGet("Subject/{Id}:guid")]
         public IActionResult GetExamApplicantsBySubjectId(Guid Id)
        {
            return Ok(service.RetriveExamApplicantsBySubjectId(Id));
        }

        [HttpGet("firstSubject/{Id}:guid")]
        public IActionResult GetExamApplicantsByFirstSubject(Guid Id)
        {
            return Ok(service.RetriveExamApplicantByFirstSubjectId(Id));
        }

        [HttpGet("secondSubject/{Id}:guid")]
        public IActionResult GetExamApplicantsBySecondSubject(Guid Id) 
        {
            return Ok(service.RetriveExamApplicantBySecondSubjectId(Id));
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
