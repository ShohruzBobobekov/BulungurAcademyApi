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

        builder.HasKey(examSubject => new { 
            examSubject.SubjectId,
            examSubject.ExamId
        });

        builder.HasOne(examSubject => examSubject.Subject)
            .WithMany()
            .HasForeignKey(examSubject => examSubject.SubjectId);

        builder.HasOne(examSubject => examSubject.Exam)
            .WithMany(exam => exam.ExamSubjects)
            .HasForeignKey(examSubject => examSubject.ExamId);
    }
}
