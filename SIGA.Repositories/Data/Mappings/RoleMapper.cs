using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Lib.Models;

namespace SIGA.Repositories.Data.Mappings;
public class RoleMapper : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder
			.ToTable("Role")
			.HasKey(x => x.Id);

		builder.HasData(new List<Role>
		{
			new Role { Id = 1, Nome = "Admin"},
			new Role { Id = 2, Nome = "TOR"},
			new Role { Id = 3, Nome = "SUITS"},
			new Role { Id = 4, Nome = "SIR"},
			new Role { Id = 5, Nome = "SAGA"},
			new Role { Id = 6, Nome = "Arrecadacao"},
			new Role { Id = 7, Nome = "Coordenacao"}
		});

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
