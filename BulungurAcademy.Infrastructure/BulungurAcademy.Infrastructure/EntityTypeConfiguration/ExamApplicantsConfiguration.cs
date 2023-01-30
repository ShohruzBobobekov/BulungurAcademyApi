using BulungurAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulungurAcademy.Infrastructure.IEntityTypeConfiguration;

public class ExamApplicantsConfiguration : IEntityTypeConfiguration<ExamApplicant>
{
    public void Configure(EntityTypeBuilder<ExamApplicant> builder)
    {
        builder.HasKey(ea => new { ea.UserId, ea.ExamId });

        builder
            .HasOne(ea => ea.User)
            .WithMany(user => user.ExamApplicants)
            .HasForeignKey(ea=>ea.UserId);

        builder
            .HasOne(ea => ea.FirstSubject)
            .WithMany()
            .HasForeignKey(ea => ea.FirstSubjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(ea => ea.SecondSubject)
            .WithMany()
            .HasForeignKey(ea => ea.SecondSubjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(ea => ea.Exam)
            .WithMany(exam => exam.ExamApplicants)
            .HasForeignKey(ea => ea.ExamId);
    }
}
