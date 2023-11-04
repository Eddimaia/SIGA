using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Lib.Models;

namespace SIGA.API.Data.Mappings;
public class RoleMapper : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder
			.ToTable("Role")
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder.Property(x => x.Nome)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(80);

		builder
			.HasMany(x => x.Funcionarios)
			.WithMany(x => x.Roles)
			.UsingEntity<Dictionary<string, object>>(
				"FuncionarioRole",
				funcionario => funcionario
					.HasOne<Funcionario>()
					.WithMany()
					.HasForeignKey("FuncionarioId")
					.HasConstraintName("FK_FuncionarioRole_FuncionarioId")
					.OnDelete(DeleteBehavior.Cascade),
				role => role
					.HasOne<Role>()
					.WithMany()
					.HasForeignKey("RoleId")
					.HasConstraintName("FK_FuncionarioRole_RoleId")
					.OnDelete(DeleteBehavior.Cascade));
	}
}
