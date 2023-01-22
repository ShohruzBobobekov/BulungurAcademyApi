using BulungurAcademy.Domain.Entities.Common;
using BulungurAcademy.Domain.Enum;

namespace BulungurAcademy.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public UserRole UserRole { get; set; }

    public ICollection<ExamApplicant>? ExamApplicants { get; set; }

    public User(string firstName, string lastName, string phone, UserRole userRole)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        UserRole = userRole;
    }
}
