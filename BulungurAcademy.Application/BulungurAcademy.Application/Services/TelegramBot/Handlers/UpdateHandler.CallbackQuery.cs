﻿using BulungurAcademy.Domain.Entities;
using BulungurAcademy.Domain.Entities.Subjects;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BulungurAcademy.Core.Services;

public partial class UpdateHandler
{
#pragma warning disable
    private async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var callDatas = callbackQuery.Data.Split(' ');

        var examId = Guid.Parse(callDatas[1]);
        Guid subjectId = new Guid();

        if (callDatas.Length > 2)
        {
            var subjectName = callDatas[2];

            Subject? subject = subjectRepository.SelectAll()
                .FirstOrDefault(subject => subject.Name.Contains(subjectName));

            subjectId = subject.Id;
        }

        var handler = callDatas[0] switch
        {
            "exam" => HandleExamCallbackQueryAsync(callbackQuery, examId),
            "subject" => HandleSubjectCallbackQueryAsync(callbackQuery, examId, subjectId),
            "confirm" => HandleConfirmCallbackQueryAsync(callbackQuery, examId)
        };

        await handler;
    }


    private async Task HandleExamCallbackQueryAsync(
        CallbackQuery callbackQuery,
        Guid examId)
    {
        var exam = await examRepository
            .SelectByIdWithDetailsAsync(exam => exam.Id == examId,
            new string[]
            {
                "Subjects"
            });

        var inlineMarkup = ServiceHelper.GenerateSubjectButttons(
            exam.Subjects.ToList(), examId);

        await telegramBotClient.EditMessageTextAsync(
            chatId: callbackQuery.From.Id,
            messageId: callbackQuery.Message.MessageId,
            text: "1. Birinchi fanni tanlang",
            replyMarkup: inlineMarkup);
    }

    private async Task HandleSubjectCallbackQueryAsync(
        CallbackQuery callbackQuery,
        Guid examId,
        Guid subjectId)
    {
        var storageUser = userRepository
            .SelectAll()
            .FirstOrDefault(user => user.TelegramId == callbackQuery.From.Id);
        if (storageUser is null)
        {
            telegramBotClient.SendTextMessageAsync(
                chatId: callbackQuery.From.Id,
                text: "*** Avval ro'yhatdan o'ting ***",
                parseMode:Telegram.Bot.Types.Enums.ParseMode.MarkdownV2);
            HandleStartCommandAsync(callbackQuery.Message);
            return;
        }
        ExamApplicant? examApplicant = examApplicantRepository
            .SelectAllWithDetailsAsync(examApplicant =>
                examApplicant.UserId == storageUser.Id
                && examApplicant.ExamId == examId,
                new string[]
                {
                    "FirstSubject","SecondSubject","Exam"
                })
            .FirstOrDefault();

        if (callbackQuery.Message.Text.StartsWith("1"))
        {
            var exam = await examRepository
            .SelectByIdWithDetailsAsync(exam => exam.Id == examId,
            new string[]
            {
                "Subjects"
            });
            if (examApplicant is not null)
            {
                examApplicant.FirstSubjectId = subjectId;
                await examApplicantRepository.UpdateAsync(examApplicant);
            }
            else
            {
                examApplicant = new ExamApplicant()
                {
                    UserId = storageUser.Id,
                    ExamId = examId,
                    FirstSubjectId = subjectId
                };
                await examApplicantRepository.InsertAsync(examApplicant);
            }
            var subjects = exam.Subjects
                .SkipWhile(subject => subject.Id == subjectId)
                .ToList();

            var inlineMarkup = ServiceHelper
                .GenerateSubjectButttons(subjects, examId);

            await telegramBotClient.EditMessageTextAsync(
                chatId: callbackQuery.From.Id,
                text: "2. Ikkinchi fanni tanlang",
                messageId: callbackQuery.Message.MessageId,
                replyMarkup: inlineMarkup);
        }
        else
        {
            examApplicant.SecondSubjectId = subjectId;

            examApplicant = await examApplicantRepository.UpdateAsync(examApplicant);
            examApplicant = examApplicantRepository
           .SelectAllWithDetailsAsync(examApplicant =>
               examApplicant.UserId == storageUser.Id
               && examApplicant.ExamId == examId,
               new string[]
               {
                    "FirstSubject","SecondSubject","Exam"
               })
           .FirstOrDefault();
            var inlineMarkup = new InlineKeyboardMarkup(
                new InlineKeyboardButton("Tasdiqlash ✅")
                {
                    CallbackData = $"confirm {examId}"
                });

            await telegramBotClient.EditMessageTextAsync(
                chatId: callbackQuery.From.Id,
                text: $" Imtihon: {examApplicant.Exam.ExamName}\n" +
                $" Vaqti: {examApplicant.Exam.GetExamDateToString()}\n" +
                $" Birinchi fan: {examApplicant.FirstSubject.Name}\n" +
                $" Ikkinchi fan: {examApplicant.SecondSubject.Name}\n\n" +
                $" Ro'yxatdan o'tish muvaffaqiyatli yakunlandi",
                messageId: callbackQuery.Message.MessageId,
                replyMarkup: inlineMarkup);
        }
    }
    private async Task HandleConfirmCallbackQueryAsync(
        CallbackQuery callbackQuery,
        Guid examId)
    {
        await telegramBotClient.DeleteMessageAsync(
                chatId: callbackQuery.From.Id,
                messageId: callbackQuery.Message.MessageId);

        var userId = userRepository.SelectAll()
            .FirstOrDefault(user => user.TelegramId == callbackQuery.From.Id).Id;

        var examApplicant = await examApplicantRepository
            .SelectByIdWithDetailsAsync(examId, userId);

        await telegramBotClient.SendTextMessageAsync(
            chatId: callbackQuery.From.Id,
            text: "Imtihonga muvaffaqiyatli ro'yxatdan o'tdingiz.\n\n" +
            $"Imtihon: {examApplicant.Exam.ExamName}," +
            examApplicant.Exam.GetExamDateToString() +
            $"Fanlaringiz: {examApplicant.FirstSubject.Name}, {examApplicant.SecondSubject.Name}"
            );
    }
}