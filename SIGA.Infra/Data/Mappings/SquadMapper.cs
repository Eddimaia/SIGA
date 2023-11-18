using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;
public class SquadMapper : IEntityTypeConfiguration<Squad>
{
	public void Configure(EntityTypeBuilder<Squad> builder)
	{
		builder
			.ToTable("Squad")
			.HasKey(x => x.Id);

		builder.HasData(new List<Squad>
		{
			new Squad { Id = 1, Nome = "Admin"},
			new Squad { Id = 2, Nome = "TOR"},
			new Squad { Id = 3, Nome = "SUITS"},
			new Squad { Id = 4, Nome = "SIR"},
			new Squad { Id = 5, Nome = "SAGA"},
			new Squad { Id = 6, Nome = "Arrecadacao"},
			new Squad { Id = 7, Nome = "Coordenacao"}
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
			.WithMany(x => x.Squads)
			.UsingEntity<Dictionary<string, object>>(
				"FuncionarioSquad",
				funcionario => funcionario
					.HasOne<Funcionario>()
					.WithMany()
					.HasForeignKey("FuncionarioId")
					.HasConstraintName("FK_FuncionarioSquad_FuncionarioId")
					.OnDelete(DeleteBehavior.Cascade),
				squad => squad
					.HasOne<Squad>()
					.WithMany()
					.HasForeignKey("SquadId")
					.HasConstraintName("FK_FuncionarioSquad_SquadId")
					.OnDelete(DeleteBehavior.Cascade));
	}
}
