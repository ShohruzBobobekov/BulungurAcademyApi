using BulungurAcademy.Application.Services.ExamApplicants;
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

        [HttpGet]
        public IActionResult GetExamApplicants()
        {
            return Ok(service.RetriveAllExamApplicants());
        }        
    }
}
