using BulungurAcademy.Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BulungurAcademy.Core.Services;

public partial class UpdateHandler
{
    private async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var callDatas = callbackQuery.Data.Split(' ');

        var examId = Guid.Parse(callDatas[1]);
        Guid subjectId = new Guid();

        if (callDatas.Length > 2 )
            subjectId = Guid.Parse(callDatas[2]);

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

        ExamApplicant? examApplicant = examApplicantRepository
            .SelectAll()
            .FirstOrDefault(examApplicant =>
                examApplicant.UserId == storageUser.Id && examApplicant.ExamId == examId);


        if (callbackQuery.Message.Text.StartsWith("1"))
        {
            var exam = await examRepository
            .SelectByIdWithDetailsAsync(exam => exam.Id == examId,
            new string[]
            {
                "Subjects"
            });

            examApplicant = new ExamApplicant()
            {
                UserId = storageUser.Id,
                ExamId = examId,
                FirstSubjectId = subjectId
            };
            await examApplicantRepository.InsertAsync(examApplicant);

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

            await examApplicantRepository.UpdateAsync(examApplicant);

            var inlineMarkup = new InlineKeyboardMarkup(
                new InlineKeyboardButton("Tasdiqlash✅")
                {
                    CallbackData = $"confirm {examId}"
                });
            

            await telegramBotClient.EditMessageTextAsync(
                chatId: callbackQuery.From.Id,
                text: "",
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

        var exam = await examRepository.SelectByIdAsync(examId);

        await telegramBotClient.SendTextMessageAsync(
            chatId: callbackQuery.From.Id,
            text: "Muvaffaqiyatli");
    }

}
