using BulungurAcademy.Domain.Entities.Subjects;
using BulungurAcademy.Infrastructure.Contexts;

namespace BulungurAcademy.Infrastructure.Repositories.Subjects;

public class SubjectRepository : Repository<Subject, Guid>, ISubjectRepository
{
	public SubjectRepository(AppDbContext appDbContext)
		: base(appDbContext)
	{

	}
}
