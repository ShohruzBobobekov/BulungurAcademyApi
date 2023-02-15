using BulungurAcademy.Application.DataTranferObjects.Exams;
using BulungurAcademy.Application.Services.Exams;
using BulungurAcademy.Domain.Entities.Exams;
using Microsoft.AspNetCore.Mvc;

namespace BulungurAcademy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExamService service;

    public ExamController(IExamService examService)
    {
        this.service = examService;
    }

    [HttpPost]
    IActionResult CreateExamAsync(ExamForCreationDto exam)
    {
        return Ok( service.CreateExamAsync(exam));
    }

    [HttpGet]
    public IActionResult GetExams()
    {
        var exams = service.RetrieveExams();

        return Ok(exams);
    }

    [HttpGet("examId:Guid")]
    public async Task<IActionResult> GetExamByIdAsync(Guid examId)
    {
        var exam = await service.RetrieveExamByIdAsync(id: examId);

        return Ok(exam);
    }
}