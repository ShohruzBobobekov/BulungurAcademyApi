using BulungurAcademy.Infrastructure.Repositories.ExamApplicants;
using BulungurAcademy.Infrastructure.Repositories.Exams;
using BulungurAcademy.Infrastructure.Repositories.Subjects;
using BulungurAcademy.Infrastructure.Repositories.Users;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BulungurAcademy.Core.Services;

public partial class UpdateHandler
{
    private readonly ITelegramBotClient telegramBotClient;
    private readonly ILogger<UpdateHandler> logger;
    private readonly IUserRepository userRepository;
    private readonly IExamRepository examRepository;
    private readonly ISubjectRepository subjectRepository;
    private readonly IExamApplicantRepository examApplicantRepository;

    public UpdateHandler(
        ITelegramBotClient telegramBotClient,
        ILogger<UpdateHandler> logger,
        ISubjectRepository subjectRepository,
        IExamRepository examRepository,
        IUserRepository userRepository,
        IExamApplicantRepository examApplicantRepository)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
        this.subjectRepository = subjectRepository;
        this.examRepository = examRepository;
        this.userRepository = userRepository;
        this.examApplicantRepository = examApplicantRepository;
    }

    public async Task UpdateHandlerAsync(Update update)
    {
        var handler = update.Type switch
        {
            UpdateType.Message => HandleCommandAsync(update.Message),
            UpdateType.CallbackQuery => HandleCallbackQueryAsync(update.CallbackQuery),
            _ => HandleNotAvailableCommandAsync(update.Message)
        };

        await handler;
    }

    private async Task HandleNotAvailableCommandAsync(Message message)
    {
        await this.telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: "Mavjud bo'lmagan komanda kiritildi.\n " +
                "Tekshirib ko'ring.");
    }
}
