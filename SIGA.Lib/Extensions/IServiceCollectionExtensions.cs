using Microsoft.Extensions.DependencyInjection;

namespace SIGA.Lib.Extensions;
public static class IServiceCollectionExtensions
{
	public static void AutoMapperBuild(this IServiceCollection services)
		=> services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}
