﻿using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Domain.Entities.Exams;
using BulungurAcademy.Domain.Entities.Subjects;
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
                    CallbackData = $"exam {examIds[index]}"
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
            builder.AppendLine(
                $"Imtihon kuni: {exam.ExamDate.Year}-yil, " +
            $"{exam.ExamDate.ToString("MMMM")} " +
            $"{exam.ExamDate.Day},\n" +
            $"Imtihon vaqti:  {exam.ExamDate.ToString("HH:MM")}\n\n");
        }

        return builder.ToString() + "</b>";
    }

    public static InlineKeyboardMarkup GenerateSubjectButttons(
        List<Subject> subjects,
        Guid examId)
    {
        var buttons = new List<List<InlineKeyboardButton>>();

        for (int index = 0; index < subjects.Count; index++)
        {
            if (index % 2 == 0)
                buttons.Add(new List<InlineKeyboardButton>());

            buttons[index / 2].Add(
                new InlineKeyboardButton($"{subjects[index].Name}")
                {
                    CallbackData = $"subject {examId} {subjects[index].Name}"
                }
            );
        }

        return new InlineKeyboardMarkup(buttons);
    }
}
