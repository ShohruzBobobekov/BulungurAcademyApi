using BulungurAcademy.Domain.Entities.ExamSubjects;
using BulungurAcademy.Infrastructure.Contexts;

namespace BulungurAcademy.Infrastructure.Repositories.ExamSubjects;

public class ExamSubjectRepository : Repository<ExamSubject>, IExamSubjectRepository
{
	public ExamSubjectRepository(AppDbContext appDbContext)
		: base(appDbContext)
	{

	}
}
