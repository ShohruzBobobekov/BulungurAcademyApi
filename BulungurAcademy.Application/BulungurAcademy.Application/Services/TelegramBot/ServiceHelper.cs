
using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Domain.Entities.Subjects;
using System;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace BulungurAcademy.Core.Services;

public static class ServiceHelper
{
    public static InlineKeyboardMarkup GenerateNextPrevButtons(int page)
    {
        var buttons = new List<InlineKeyboardButton>()
        {
            new InlineKeyboardButton("⏪")
            {
                CallbackData = $"prev {page}"
            },
            new InlineKeyboardButton("⏩")
            {
                CallbackData = $"next {page}"
            }
        };

        return new InlineKeyboardMarkup(buttons);
    }

    public static InlineKeyboardMarkup GenerateExamsButtons(List<Guid> examIds)
    {
        var buttons = new List<List<InlineKeyboardButton>>();

        for (int index = 0; index < examIds.Count; index++)
        {
            if (index % 3 == 0)
                buttons.Add(new List<InlineKeyboardButton>());

            buttons[index / 3].Add(
                new InlineKeyboardButton($"{index + 1}")
                {
                    CallbackData = "exam " + examIds[index].ToString()
                }
            );
        }

        return new InlineKeyboardMarkup(buttons);
    }

    public static string TableBuilder(List<Exam> exams)
    {
        var builder = new StringBuilder();
        builder.AppendLine("\tImtihonlar ro'yxati<b>");
        int index = 1;

        foreach (var exam in exams)
        {
            builder.AppendLine($"\n{index++}. Imtihon nomi: {exam.ExamName}");
            builder.AppendLine($"Imtihon vaqti: {exam.ExamDate}");
        }

        return builder.ToString() + "</b>";
    }

    public static InlineKeyboardMarkup GenerateSubjectButttons(List<Subject> subjects)
    {
        var buttons = new List<InlineKeyboardButton>();

        foreach (var subject in subjects)
        {
            new InlineKeyboardButton($"{subject.Name}")
            {
                CallbackData = "subject " + subject.Id.ToString()
            };
        }
        return new InlineKeyboardMarkup(buttons);
    }
}
