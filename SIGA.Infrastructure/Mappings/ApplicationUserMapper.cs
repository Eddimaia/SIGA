using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings;
public class ApplicationUserMapper : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .ToTable(nameof(ApplicationUser))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");

        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .Property(x => x.Login)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");

        builder
            .Property(x => x.UserName)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");

        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");

        builder
            .Property(x => x.PhoneNumber)
            .IsRequired(false)
            .HasColumnType("VARCHAR(15)");

        builder
            .Property(x => x.BirthDate)
            .IsRequired()
            .HasColumnType("DATE");

        builder
            .Property(x => x.LastLoginDate)
            .IsRequired(false)
            .HasColumnType("DATETIMEOFFSET");

        builder
            .Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("DATETIMEOFFSET");

        builder
            .Property(x => x.IsEmailConfirmed)
            .IsRequired()
            .HasColumnType("BIT");

        builder
            .Property(x => x.IsPhoneNumberConfirmed)
            .IsRequired()
            .HasColumnType("BIT");

        builder
            .Property(x => x.IsEmployed)
            .IsRequired()
            .HasColumnType("BIT");

        builder
            .Property(x => x.IsProjectCoordinator)
            .IsRequired()
            .HasColumnType("BIT");

        builder
            .Property(x => x.ImagePath)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.ApplicationUsers)
            .UsingEntity<ApplicationUserRole>();

        builder
            .HasMany(x => x.Projects)
            .WithMany(x => x.ApplicationUsers)
            .UsingEntity<ApplicationUserProject>();

        builder
            .HasMany(x => x.Claims)
            .WithMany(x => x.ApplicationUsers)
            .UsingEntity<ApplicationUserClaim>();

        builder
            .HasMany(x => x.CoordinatorProjects)
            .WithOne(x => x.Coordinator)
            .HasConstraintName("FK_Project_CoordinatorId")
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasIndex(x => x.Email)
            .IsUnique();

        builder
            .HasIndex(x => x.UserName)
            .IsUnique();

        builder
            .HasIndex(x => x.Login)
            .IsUnique();
    }
}
