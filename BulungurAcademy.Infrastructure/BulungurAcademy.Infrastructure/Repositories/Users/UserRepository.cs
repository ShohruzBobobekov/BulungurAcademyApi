using BulungurAcademy.Domain.Entities.Users;
using BulungurAcademy.Infrastructure.Contexts;

namespace BulungurAcademy.Infrastructure.Repositories.Users;

public class UserRepository : Repository<User>, IUserRepository
{
	public UserRepository(AppDbContext appDbContext)
		: base(appDbContext)
	{
	}
}
