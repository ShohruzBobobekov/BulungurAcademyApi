using BulungurAcademy.Application.Services.Exams;
using BulungurAcademy.Domain.Entities.Exams;
using Microsoft.AspNetCore.Mvc;

namespace BulungurAcademy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExamService examService;

    public ExamController(IExamService examService)
    {
        this.examService = examService;
    }

    [HttpGet]
    public IActionResult GetExams()
    {
        var exams = examService.RetrieveExams();

        return Ok(exams);
    }

    [HttpGet("examId:Guid")]
    public async Task<IActionResult> GetExamByIdAsync(Guid examId)
    {
        var exam = await examService.RetrieveExamByIdAsync(id: examId);

        return Ok(exam);
    }

    [HttpPost] IActionResult CreateExamAsync(Exam exam)
    {

    }
}