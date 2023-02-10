using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Infrastructure.Contexts;

namespace BulungurAcademy.Infrastructure.Repositories.ExamApplicants;

public class ExamApplicantRepository : Repository<ExamApplicant>, IExamApplicantRepository
{
	public ExamApplicantRepository(AppDbContext appDbContext)
		: base(appDbContext)
	{

	}

    public async ValueTask<ExamApplicant> SelectByIdWithDetailsAsync(Guid examId, Guid userId)
    {
      return await  SelectByIdWithDetailsAsync(examApplicant =>
             examApplicant.UserId == userId
                && examApplicant.ExamId == examId,
                new string[] { "User", "Exam", "FirstSubject", "SecondSubject" });
    }
}
