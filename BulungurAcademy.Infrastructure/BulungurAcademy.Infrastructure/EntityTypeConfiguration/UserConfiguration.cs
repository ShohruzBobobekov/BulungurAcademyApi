using BulungurAcademy.Domain.Constants;
using BulungurAcademy.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulungurAcademy.Infrastructure.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.ToTable(TableNames.Users);

        builder.HasKey(user => user.Id);

        builder.Property(user=>user.FirstName)
            .IsRequired(true)
            .HasMaxLength(100);

        builder.Property(user=>user.LastName)
            .IsRequired(true)
            .HasMaxLength(100);

        builder.Property(user => user.TelegramId)
            .IsRequired(false);
            
    }
}
