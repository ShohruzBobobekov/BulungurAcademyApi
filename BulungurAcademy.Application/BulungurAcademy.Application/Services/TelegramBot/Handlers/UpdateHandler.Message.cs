using BulungurAcademy.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace BulungurAcademy.Core.Services;

public partial class UpdateHandler
{
    private const long AdminId = 5722560663;

    public async Task HandleCommandAsync(Message message)
    {
        if (message.Contact is not null)
        {
            await HandleContactMessageAsync(message);
            return;
        }

        if (message.Text is null)
            return;

        var command = message.Text.Split(' ').First().Substring(0);

        try
        {
            var task = command switch
            {
                "/start" => HandleStartCommandAsync(message),
                "Men:" => HandleRegisterCommandAsync(message),
                "Imtihonlar" => HandleExamCommandAsync(message),
                "#Diqqat" => HandleAnnouncement(message),
                _ => HandleNotAvailableCommandAsync(message)
            };

            await task;
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception.Message);

            await this.telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: exception.Message);

            return;
        }
    }

    private async Task HandleAnnouncement(Message message)
    {
        if (message.Chat.Id != AdminId)
            return;

        var users = userRepository.SelectAll();
        foreach (var user in users)
        {
            try
            {
                if (user.TelegramId is not null)
                {
                    await telegramBotClient.ForwardMessageAsync(
                         chatId: user.TelegramId,
                         fromChatId: AdminId,
                         message.MessageId,
                         protectContent: true);
                }
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                await telegramBotClient.SendTextMessageAsync(
                    chatId: AdminId,
                    text: e.Message + "\n\n " + user.FirstName + "  " + user.LastName);
                user.TelegramId = null;
                await userRepository.UpdateAsync(user);
            }
        }
    }

    private async Task HandleStartCommandAsync(Message message)
    {
        await SendTextMessageToClient(
                chatId: message.Chat.Id,
                text: "Bulung'ur academy botiga xush kelibsiz! " +
                "Botdan foydlanish uchun ro'yxatdan o'ting. " +
                "Familiya, Ismingizni quyidagi formatda yuboring 👇\n\n" +
                "Misol uchun: <b>  Men: Bobobekov Shohruz</b>",
                parseMode: ParseMode.Html);
    }

    private async Task HandleRegisterCommandAsync(Message message)
    {
        var user = MessageFactory.MapToUserInfo(message.Text);

        user.TelegramId = message.From.Id;
        user.CreatedAt = DateTime.UtcNow;

        await userRepository.InsertAsync(user);

        var markup = new ReplyKeyboardMarkup(
                KeyboardButton.WithRequestContact("Tel raqami"));

        markup.ResizeKeyboard = true;

        await SendTextMessageToClient(
             message.From.Id,
             text: "Kontaktingizni yuboring!",
             replyMarkup: markup);
    }

    private async Task HandleContactMessageAsync(Message message)
    {
        Contact contact = message.Contact;

        var storageUser = userRepository
            .SelectAll()
            .FirstOrDefault(user => user.TelegramId == contact.UserId);

        if (storageUser == null)
        {
            throw new NotFoundException("Ro'yhatda sizning malumotlaringiz topilmadi");
        }

        storageUser.Phone = contact.PhoneNumber;
        storageUser.UpdatedAt = DateTime.UtcNow;

        await userRepository.UpdateAsync(storageUser);

        var markup = new ReplyKeyboardMarkup(
            new KeyboardButton("Imtihonlar ro'yxati"));
        markup.ResizeKeyboard = true;

       await telegramBotClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            "Kontakt saqlqndi Imtihonni tanlang: ",
            replyMarkup: markup);
    }

    private async Task HandleExamCommandAsync(Message message)
    {
        var exams = examRepository.SelectAll();

        var data = ServiceHelper
            .TableBuilder(exams.ToList());

        var list = exams.Select(exam => exam.Id).ToList();

        var buttons = ServiceHelper.GenerateExamsButtons(list);

        await SendTextMessageToClient(
            chatId: message.From.Id,
            text: data,
            replyMarkup: buttons);
    }

    private async Task SendTextMessageToClient(
        long chatId,
        string text,
        IReplyMarkup? replyMarkup = null,
        ParseMode? parseMode = ParseMode.Html
        )
    {
        await telegramBotClient.SendTextMessageAsync(
             chatId: chatId,
             text: text,
             replyMarkup: replyMarkup,
             parseMode: parseMode);
    }
}


