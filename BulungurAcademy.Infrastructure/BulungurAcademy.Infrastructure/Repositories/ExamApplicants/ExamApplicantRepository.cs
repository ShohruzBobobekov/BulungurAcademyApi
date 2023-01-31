using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Infrastructure.Contexts;

namespace BulungurAcademy.Infrastructure.Repositories.ExamApplicants;

public class ExamApplicantRepository : Repository<ExamApplicant>, IExamApplicantRepository
{
	public ExamApplicantRepository(AppDbContext appDbContext)
		: base(appDbContext)
	{

	}
}
