using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings.Relations;
public class ApplicationUserRoleMapper : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder
            .ToTable(nameof(ApplicationUserRole))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .HasOne(x => x.ApplicationUser)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.ApplicationUserId)
            .HasConstraintName("FK_UserRoleMapper_ApplicationUser")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .HasConstraintName("FK_UserRoleMapper_Role")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
