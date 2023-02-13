using BulungurAcademy.Domain.Constants;
using BulungurAcademy.Domain.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulungurAcademy.Infrastructure.EntityTypeConfiguration;

public class SubjectConfuguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable(TableNames.Subjects);

        builder.Property(subject => subject.Name)
            .HasMaxLength(100);
        builder.HasData(GenerateData());
    }

    private List<Subject> GenerateData()
    {
        var data = new List<Subject>()
        {
            new Subject
            {
                Id=Guid.NewGuid(),
                Name="Matematika",
                UpdatedAt=new DateTime(),
                CreatedAt= DateTime.Now
            },
            new Subject
            {
                Id=Guid.NewGuid(),
                Name="Fizika",
                UpdatedAt=new DateTime(),
                CreatedAt= DateTime.Now
            }
        };
        return data;
    }
}
