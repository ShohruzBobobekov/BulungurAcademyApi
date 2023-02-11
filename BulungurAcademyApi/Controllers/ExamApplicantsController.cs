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
        public IActionResult GetExamApplicants()
        {
            return Ok(service.RetriveAllExamApplicants());
        }

    }
}
