using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infraestructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name).Property(x => x.FirstName).HasColumnType("NVARCHAR").HasMaxLength(100).HasColumnName("FirstName").IsRequired();

        builder.OwnsOne(x => x.Name).Property(x => x.LastName).HasColumnType("NVARCHAR").HasMaxLength(100).HasColumnName("LastName").IsRequired();

        builder.OwnsOne(x => x.Email).Property(x => x.Address).HasColumnName("Email").IsRequired();

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Property(x => x.Code).HasColumnName("EmailVerificationCode").IsRequired(true);

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Property(x => x.ExpiresAt).HasColumnName("EmailVerificationExpiresAt").IsRequired(false);

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Property(x => x.VerifiedAt).HasColumnName("EmailVerificationVerifiedAt").IsRequired(false);

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Ignore(x => x.IsActive);

        builder.OwnsOne(x => x.Password).Property(x => x.Hash).HasColumnName("PasswordHash").IsRequired();
    }
}