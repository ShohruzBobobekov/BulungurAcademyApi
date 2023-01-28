using BulungurAcademy.Domain.Constants;
using BulungurAcademy.Domain.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulungurAcademy.Infrastructure.EntityTypeConfiguration;

public class SubjectConfuguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable(TableNames.Subjects);

        builder.Property(subject => subject.Name)
            .HasMaxLength(100);
    }
}
