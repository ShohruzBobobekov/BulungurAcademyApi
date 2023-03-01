using BulungurAcademy.Domain.Entities.Subjects;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BulungurAcademy.Core.Services;

public partial class UpdateHandler
{
    private async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var callDatas = callbackQuery.Data.Split(' ');

        var id = Guid.Parse(callDatas[1]);

        var handler = callDatas[0] switch
        {
            "exam" => HandleExamCallbackQueryAsync(callbackQuery, id),
            "subject" => HandleSubjectCallbackQueryAsync(callbackQuery, id)
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

        var inlineMarkup = ServiceHelper
            .GenerateSubjectButttons(exam.Subjects.ToList());

        await telegramBotClient.EditMessageTextAsync(
            chatId: callbackQuery.From.Id,
            messageId: callbackQuery.Message.MessageId,
            text: "Birinchi va ikkinchi fanlaringizni tanlang",
            replyMarkup: inlineMarkup);
    }

    private async Task HandleSubjectCallbackQueryAsync(
        CallbackQuery callbackQuery,
        Guid subjectId)
    {
        
        

    }

}
