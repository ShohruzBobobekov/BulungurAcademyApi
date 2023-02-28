using BulungurAcademy.Domain.Entities.Common;
using BulungurAcademy.Domain.Enum;

namespace BulungurAcademy.Domain.Entities.Users;

public class User : Auditable
{
    public long? TelegramId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public UserStatus Status { get; set; }
    public UserRole UserRole { get; set; }

    public ICollection<ExamApplicant>? ExamApplicants { get; set; }

    public User(string firstName, string lastName, string phone, long? telegramId, UserRole userRole,UserStatus status=UserStatus.Inactive )
    {
        TelegramId = telegramId;
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        UserRole = userRole;
        Status = status;
    }
}
