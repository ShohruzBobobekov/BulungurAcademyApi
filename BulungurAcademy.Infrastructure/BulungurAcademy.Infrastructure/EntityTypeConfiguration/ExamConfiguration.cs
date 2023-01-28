using BulungurAcademy.Domain.Constants;
using BulungurAcademy.Domain.Entities.Exams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulungurAcademy.Infrastructure.EntityTypeConfiguration;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable(TableNames.Exams);

        builder.Property(exam=>exam.ExamName)
            .HasMaxLength(256);
    }
}
