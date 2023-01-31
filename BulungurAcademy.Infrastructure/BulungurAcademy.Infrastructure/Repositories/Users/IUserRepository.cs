using BulungurAcademy.Domain.Entities.Users;

namespace BulungurAcademy.Infrastructure.Repositories.Users;

public interface IUserRepository : IRepository<User, Guid>
{
}
