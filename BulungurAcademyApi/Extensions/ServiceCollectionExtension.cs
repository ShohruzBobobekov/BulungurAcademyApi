using BulungurAcademy.Infrastructure.Contexts;
using BulungurAcademy.Infrastructure.Repositories.ExamApplicants;
using BulungurAcademy.Infrastructure.Repositories.Exams;
using BulungurAcademy.Infrastructure.Repositories.ExamSubjects;
using BulungurAcademy.Infrastructure.Repositories.Subjects;
using BulungurAcademy.Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace BulungurAcademy.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDbContexts(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString=configuration.GetConnectionString("SqlServer");

        services.AddDbContextPool<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure();
            });
        });

        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExamApplicantRepository, ExamApplicantRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IExamSubjectRepository, ExamSubjectRepository>();

        return services;
    }
}
