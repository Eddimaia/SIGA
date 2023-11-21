using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Infra.Data.Mappings;
public class IdentityUserMapper : IEntityTypeConfiguration<IdentityUser<string>>
{
	public void Configure(EntityTypeBuilder<IdentityUser<string>> builder)
	{
		builder.ToTable("User", schema: "identity");
	}
}
