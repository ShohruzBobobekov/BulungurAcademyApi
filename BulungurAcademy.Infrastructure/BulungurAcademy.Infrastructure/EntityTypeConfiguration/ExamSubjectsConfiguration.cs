using BulungurAcademy.Domain.Constants;
using BulungurAcademy.Domain.Entities.ExamSubjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulungurAcademy.Infrastructure.EntityTypeConfiguration;

public class ExamSubjectsConfiguration : IEntityTypeConfiguration<ExamSubject>
{
    public void Configure(EntityTypeBuilder<ExamSubject> builder)
    {
        builder.ToTable(TableNames.ExamsSubjects);

        builder.
    }
}
