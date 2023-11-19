using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIGA.Repositories.Data.Mappings;
public class RoleMapper : IEntityTypeConfiguration<IdentityRole<byte>>
{
	public void Configure(EntityTypeBuilder<IdentityRole<byte>> builder)
	{
		builder.HasData(new List<IdentityRole<byte>>
		{
			new() { Id = 1, Name = "Admin"},
			new() { Id = 2, Name = "TOR"},
			new() { Id = 3, Name = "SUITS"},
			new() { Id = 4, Name = "SIR"},
			new() { Id = 5, Name = "SAGA"},
			new() { Id = 6, Name = "Arrecadacao"},
			new() { Id = 7, Name = "Coordenacao"}
		});
	}
}
