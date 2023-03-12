using BulungurAcademy.Api.Extensions;
using BulungurAcademy.Api.Middlewares;
using System.Text.Json.Serialization;
using Telegram.Bot;

namespace BulungurAcademyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContexts(builder);

            builder.Services
                .AddControllers()
                .AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            builder.Services
                .AddApplication()
                .AddInfrastructure()
                .AddTelegramBotClient(builder.Configuration)
                .AddControllerMappers()
                .AddUpdateHandeler();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.MapControllers();

            var task=SetWebHookAsync(app, builder.Configuration);
                   task.Wait();
            app.Run();
        }

        public static async Task SetWebHookAsync(
        IApplicationBuilder builder,
        IConfiguration configuration)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
                var baseUrl = configuration.GetSection("TelegramBot:BaseAddress").Value;
                var webHookUrl = $"{baseUrl}/bot";

                var webhookInfo = botClient.GetWebhookInfoAsync().Result;

                if (webhookInfo is null || webhookInfo.Url != webHookUrl)
                {
                   await botClient.SetWebhookAsync(webHookUrl);
                }
            }
        }
    }
}