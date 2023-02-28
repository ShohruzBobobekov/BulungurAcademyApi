using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Domain.Entities.Users;
using BulungurAcademy.Domain.Enum;
using System.Text.RegularExpressions;

namespace BulungurAcademy.Core.Services;

public class MessageFactory
{
    public static User MapToUserInfo(string text)
    {
        var data = text.Split(new char[] { ' ', '\t', '\n', '\r' },
            StringSplitOptions.RemoveEmptyEntries);

        if (data.Length != 3)
        {
            throw new FormatException("Invalid format");
        }

        string firstName = data[1].ToUpper();
        string lastName = data[2].ToUpper();
        string phoneNumber = "+998000000000";

        return new User(
            firstName: firstName,
            lastName: lastName,
            phone: phoneNumber,
            userRole: UserRole.User,
            telegramId: null);
    }
}
