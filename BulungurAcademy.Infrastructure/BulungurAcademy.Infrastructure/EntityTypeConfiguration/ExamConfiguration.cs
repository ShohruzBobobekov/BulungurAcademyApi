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

        builder.Property(exam => exam.ExamName)
            .HasMaxLength(256);
        builder.HasData(GenerateData());
    }

    private List<Exam> GenerateData()
    {
        var data = new List<Exam>()
        {
            new Exam
            {
                Id=new Guid("be04ecde-1fc4-4716-be35-eef6d6d8e910"),
                ExamName="Imtihon 1",
                ExamDate=new DateTime(year:2023,month:4,day:21),
                CreatedAt= DateTime.Now,
            }
        };
        return data;
    }
}

